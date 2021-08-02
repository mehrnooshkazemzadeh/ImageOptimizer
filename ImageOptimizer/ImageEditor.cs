using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Partikan.Framework.Core.Tools
{
    public class ImageEditor : IImageEditor
    {

        public Image Image { get; set; }
        public ImageEditor()
        {

        }


        public Image LoadImage(byte[] image)
        {
            using (var ms = new MemoryStream(image))
            {
                return Image.FromStream(ms);
            }
        }

        public System.Drawing.Image LoadImage(string fileName)
        {
            return Image.FromFile(fileName);
        }
        public Image LoadImage(Stream stream)
        {
            return Image.FromStream(stream);
        }
        public Image GetThumbnail(int width)
        {
            var imageHeight = Image.Height;
            var imageWidth = Image.Width;
            var targetWidth = width;
            var targetHeight = width;
            if (imageWidth > imageHeight)
            {
                targetHeight = (width * imageHeight) / imageWidth;
            }
            else
            {
                targetWidth = (width * imageWidth) / imageHeight;

            }
            return GetThumbnail(targetWidth, targetHeight);

        }
        public Image GetThumbnailWithHeight(int height)
        {
            var imageHeight = Image.Height;
            var imageWidth = Image.Width;
            var targetWidth = height;
            var targetHeight = height;
            if (imageWidth < imageHeight)
            {
                targetWidth = (height * imageWidth) / imageHeight;
            }
            else
            {
                targetHeight = (height * imageHeight) / imageWidth;

            }
            return GetThumbnail(targetWidth, targetHeight);

        }
        public Image GetThumbnail(int width, int height)
        {
            try
            {
                return Image.GetThumbnailImage(width, height, () => false, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                var message = ExceptionParser.Parse(ex);
                throw ex;
            }
        }
        public void Resize(Bitmap image, int height, string destinationPath)
        {
            try
            {
                var imageHeight = image.Height;
                var imageWidth = image.Width;
                var targetWidth = height;
                var targetHeight = height;
                if (imageWidth < imageHeight)
                {
                    targetWidth = (height * imageWidth) / imageHeight;
                }
                else
                {
                    targetHeight = (height * imageHeight) / imageWidth;

                }
                Bitmap newImage = new Bitmap(targetWidth, targetHeight);

                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(image, new Rectangle(0, 0, newImage.Width, newImage.Height));

                    var myBrush = new SolidBrush(Color.FromArgb(70, 205, 205, 205));

                    double diagonal = Math.Sqrt(newImage.Width * newImage.Width + newImage.Height * newImage.Height);

                    Rectangle containerBox = new Rectangle();

                    containerBox.X = (int)(diagonal / 10);
                    //float messageLength = (float)(diagonal / message.Length * 1);
                    //containerBox.Y = -(int)(messageLength / 1.6);

                    //Font stringFont = new Font("verdana", messageLength);

                    StringFormat sf = new StringFormat();

                    float slope = (float)(Math.Atan2(newImage.Height, newImage.Width) * 180 / Math.PI);

                    gr.RotateTransform(slope);
                    //gr.DrawString(message, stringFont, myBrush, containerBox, sf);
                    SaveOptimizeImage( newImage,destinationPath,98);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public int Calculations(decimal w1, decimal h1, int newWidth)
        {
            decimal height = 0;
            decimal ratio = 0;


            if (newWidth < h1)
            {
                ratio = w1 / newWidth;
                height = h1 / ratio;

                return Convert.ToInt32(height);
            }

            if (h1 < newWidth)
            {
                ratio = newWidth / w1;
                height = h1 * ratio;
                return Convert.ToInt32(height);
            }

            return Convert.ToInt32(height);
        }

        public void SaveREsizeImage(int height,string file , string destinationPath)
        {
            Bitmap tempBmp = new Bitmap(file);
            Bitmap bmp = new Bitmap(tempBmp, 158, 220);

            bmp.Save(
            destinationPath,
            System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        public byte[] GetThumbnailImage(int width)
        {
            var img = GetThumbnail(width);
            return ((MemoryStream)ConvertImageToStream(img)).ToArray();
        }

        public byte[] GetThumbnailImage(int width, int height)
        {
            var img = GetThumbnail(width, height);
            return ((MemoryStream)ConvertImageToStream(img)).ToArray();
        }

        public Stream GetThumbnailStream(int width)
        {
            var thumbnail = GetThumbnail(width);

            return ConvertImageToStream(thumbnail);
        }

        public Stream GetThumbnailStream(int width, int height)
        {
            return ConvertImageToStream(GetThumbnail(width, height));
        }
        public string UploadFile(string file, string targetPath)
        {
            if (string.IsNullOrWhiteSpace(file))
                return null;
            var uploadFolder = targetPath;
            if (!File.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);
            var filePath = Path.Combine(uploadFolder, file);
            File.Copy(file, filePath);
            return filePath;
        }
        public Image SetWatermark(WatermarkBase waterMarkBase)
        {
            if (waterMarkBase.WatermarkImage == null)
                MessageBox.Show("Invalid WaterMark Image");
            if (waterMarkBase.Opacity < 0 || waterMarkBase.Opacity > 1)
                MessageBox.Show("Invalid WaterMark Opacity");
            if (waterMarkBase.ScaleRatio <= 0)
                MessageBox.Show("Invalid WaterMark ScaleRatio");
            var watermark = GetWatermarkImage(waterMarkBase);
            watermark.RotateFlip(waterMarkBase.RotateFlip);

            var waterPos = GetWatermarkPosition(waterMarkBase);

            var destRect = new Rectangle(waterPos.X, waterPos.Y, watermark.Width, watermark.Height);

            var colorMatrix = new ColorMatrix(
                new float[][] {
                    new float[] { 1, 0f, 0f, 0f, 0f},
                    new float[] { 0f, 1, 0f, 0f, 0f},
                    new float[] { 0f, 0f, 1, 0f, 0f},
                    new float[] { 0f, 0f, 0f, waterMarkBase.Opacity, 0f},
                    new float[] { 0f, 0f, 0f, 0f, 1}
                });

            var attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);

            if (waterMarkBase.TransparentColor != Color.Empty)
            {
                attributes.SetColorKey(waterMarkBase.TransparentColor, waterMarkBase.TransparentColor);
            }
            using (var gr = Graphics.FromImage(waterMarkBase.Image))
            {
                gr.DrawImage(watermark, destRect, 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, attributes);
            }
            return waterMarkBase.Image;
        }

        public Image SetWatermarkText(WatermarkBase watermarkBase, string text)
        {
            watermarkBase.WatermarkImage = GetTextWatermark(watermarkBase, text);
            return SetWatermark(watermarkBase);
        }

        public void SaveWatermark(WatermarkBase waterMarkBase, string targetFile)
        {
            var img = SetWatermark(waterMarkBase);
            img.Save(targetFile);
        }
        public void SaveThumbnailToFile(int width, string imageFile, string targetFile)
        {
            Image = LoadImage(imageFile);
            var thumbnail = GetThumbnail(width);
            thumbnail.Save(targetFile);
        }
        public void SaveThumbnailToFile(int width, int height, string imageFile, string targetFile)
        {
            Image = LoadImage(imageFile);
            var thumbnail = GetThumbnail(width, height);
            thumbnail.Save(targetFile);
        }
        public void SaveThumbnailToFileWithHeight(int height, string imageFile, string targetFile)
        {
            Image = LoadImage(imageFile);
            var thumbnail = GetThumbnailWithHeight( height);
            thumbnail.Save(targetFile);
        }
        private Stream ConvertImageToStream(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms;
            }
        }

        private Image GetTextWatermark(WatermarkBase watermarkBase, string text)
        {
            var brush = new SolidBrush(watermarkBase.FontColor);
            using (Graphics g = Graphics.FromImage(watermarkBase.Image))
            {
                var size = g.MeasureString(text, watermarkBase.Font);
                var bitmap = new Bitmap((int)size.Width, (int)size.Height);
                bitmap.SetResolution(watermarkBase.Image.HorizontalResolution, watermarkBase.Image.VerticalResolution);
                using (Graphics graf = Graphics.FromImage(bitmap))
                {
                    graf.DrawString(text, watermarkBase.Font, brush, 0, 0);
                }
                return bitmap;
            }
        }
        private Image GetWatermarkImage(WatermarkBase watermark)
        {

            //if (m_margin.All == 0 && m_scaleRatio == 1.0f)
            //    return watermark;

            int newWidth = Convert.ToInt32(watermark.WatermarkImage.Width * watermark.ScaleRatio);
            int newHeight = Convert.ToInt32(watermark.WatermarkImage.Height * watermark.ScaleRatio);
            var sourceRect = new Rectangle(0, 0, newWidth, newHeight);
            var destRect = new Rectangle(0, 0, watermark.WatermarkImage.Width, watermark.WatermarkImage.Height);

            var bitmap = new Bitmap(newWidth + 0 + 0, newHeight + 0 + 0);
            bitmap.SetResolution(watermark.WatermarkImage.HorizontalResolution, watermark.WatermarkImage.VerticalResolution);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(watermark.WatermarkImage, sourceRect, destRect, GraphicsUnit.Pixel);
            }
            return bitmap;
        }
        private Point GetWatermarkPosition(WatermarkBase watermarkBase)
        {
            int x = 0;
            int y = 0;
            int watermarkWidth = watermarkBase.WatermarkImage.Width;
            int watermarkHeight = watermarkBase.WatermarkImage.Height;
            int imageWidth = watermarkBase.Image.Width;
            int imageHeight = watermarkBase.Image.Height;
            switch (watermarkBase.Position)
            {
                case WatermarkPosition.Absolute:
                    x = watermarkBase.PositionX; y = watermarkBase.PositionX;
                    break;
                case WatermarkPosition.TopLeft:
                    x = 0; y = 0;
                    break;
                case WatermarkPosition.TopRight:
                    x = imageWidth - watermarkWidth; y = 0;
                    break;
                case WatermarkPosition.TopMiddle:
                    x = (imageWidth - watermarkWidth) / 2; y = 0;
                    break;
                case WatermarkPosition.BottomLeft:
                    x = 0; y = imageHeight - watermarkHeight;
                    break;
                case WatermarkPosition.BottomRight:
                    x = imageWidth - watermarkWidth; y = imageHeight - watermarkHeight;
                    break;
                case WatermarkPosition.BottomMiddle:
                    x = (imageWidth - watermarkWidth) / 2; y = imageHeight - watermarkHeight;
                    break;
                case WatermarkPosition.MiddleLeft:
                    x = 0; y = (imageHeight - watermarkHeight) / 2;
                    break;
                case WatermarkPosition.MiddleRight:
                    x = imageWidth - watermarkWidth; y = (imageHeight - watermarkHeight) / 2;
                    break;
                case WatermarkPosition.Center:
                    x = (imageWidth - watermarkWidth) / 2; y = (imageHeight - watermarkHeight) / 2;
                    break;
                default:
                    break;
            }

            return new Point(x, y);
        }

        public void SaveOptimizeImage(Image img, string targetPath, int quality)
        {
            if (quality < 0 || quality > 100)
                throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");
            using (var fs = new FileStream(targetPath, FileMode.Create, FileAccess.ReadWrite))
            {
                var qualityParam = new EncoderParameter(Encoder.Quality, quality);
                var jpegCodec = GetEncoderInfo("image/jpeg");
                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = qualityParam;
                var newimg = new Bitmap(img);
                img.Dispose();
                newimg.Save(fs, jpegCodec, encoderParams);
                newimg.Dispose();
            }
        }
        public void SaveOptimizeImage(string imagePath, string targetPath, int quality)
        {
            var img = Image.FromFile(imagePath);
            SaveOptimizeImage(img, targetPath, quality);
        }
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            var codecs = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        public Image RotateImage(string imageFile, RotateFlipType rotateFlip)
        {
            var img = LoadImage(imageFile);
            img.RotateFlip(rotateFlip);
            return img;
        }

        public string RotateImage(string imageFile, RotateFlipType rotateFlip, string targetFile)
        {
            var img = RotateImage(imageFile, rotateFlip);
            if (string.IsNullOrWhiteSpace(targetFile))
            {
                var temp = imageFile.Split('/');
                var imageName = temp[temp.Length - 1].Split('.')[0] + "_rotate";
                targetFile = $"{imageFile.Substring(0, imageFile.LastIndexOf('/') + 1)}{imageName}.jpg";
            }
            img.Save(targetFile);
            return targetFile;
        }

        public string[] UnZip(string fileName, string extractPath)
        {
            if (!System.IO.File.Exists(extractPath))
                System.IO.Directory.CreateDirectory(extractPath);
            try
            {
                ZipFile.ExtractToDirectory(fileName, extractPath);
            }
            catch { }
            var imgFile = Directory.GetFiles(extractPath);
            return imgFile;
        }
    }


}

