using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Dithering
{
    public static class Dither
    {
        /// <summary>
        /// Performs Sierra-2-4A dithering on the specified bitmap's data.
        /// </summary>
        /// <param name="bmp"></param>
        /// <remarks>
        /// (1/4)
        ///     *   2
        /// 1   1
        /// </remarks>
        public static void Sierra24A(WriteableBitmap bmp)
        {
            for (int y = 0; y < bmp.PixelHeight; y++)
            {
                for (int x = 0; x < bmp.PixelWidth; x++)
                {
                    var px = GetPixel(bmp, x, y);
                    var modPx = Downsample(px);

                    SetPixel(bmp, x, y, modPx);

                    var redError = px.R - modPx.R;
                    var greenError = px.G - modPx.G;
                    var blueError = px.B - modPx.B;

                    Color npx;
                    if (x < bmp.PixelWidth - 1)
                    {
                        // Right pixel
                        npx = GetPixel(bmp, x + 1, y);
                        SetPixel(bmp, x + 1, y, ModifyColor(npx, 2.0 / 4, redError, greenError, blueError));
                    }
                    if (y < bmp.PixelHeight - 1)
                    {
                        // Bottom pixel
                        npx = GetPixel(bmp, x, y + 1);
                        SetPixel(bmp, x, y + 1, ModifyColor(npx, 1.0 / 4, redError, greenError, blueError));

                        if (x > 0)
                        {
                            // Bottom left pixel
                            npx = GetPixel(bmp, x - 1, y + 1);
                            SetPixel(bmp, x - 1, y + 1, ModifyColor(npx, 1.0 / 4, redError, greenError, blueError));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Performs Sierra2 dithering on the specified bitmap's data.
        /// </summary>
        /// <param name="bmp"></param>
        /// <remarks>
        /// (1/16)
        ///         *   4   3
        /// 1   2   3   2   1
        /// </remarks>
        public static void Sierra2(WriteableBitmap bmp)
        {
            for (int y = 0; y < bmp.PixelHeight; y++)
            {
                for (int x = 0; x < bmp.PixelWidth; x++)
                {
                    var px = GetPixel(bmp, x, y);
                    var modPx = Downsample(px);

                    SetPixel(bmp, x, y, modPx);

                    var redError = px.R - modPx.R;
                    var greenError = px.G - modPx.G;
                    var blueError = px.B - modPx.B;

                    Color npx;
                    if (x < bmp.PixelWidth - 1)
                    {
                        // Near-right pixel
                        npx = GetPixel(bmp, x + 1, y);
                        SetPixel(bmp, x + 1, y, ModifyColor(npx, 4.0 / 16, redError, greenError, blueError));
                    }
                    if (x < bmp.PixelWidth - 2)
                    {
                        // Far-right pixel
                        npx = GetPixel(bmp, x + 2, y);
                        SetPixel(bmp, x + 2, y, ModifyColor(npx, 3.0 / 16, redError, greenError, blueError));
                    }
                    if (y < bmp.PixelHeight - 1)
                    {
                        // Bottom pixel
                        npx = GetPixel(bmp, x, y + 1);
                        SetPixel(bmp, x, y + 1, ModifyColor(npx, 3.0 / 16, redError, greenError, blueError));

                        if (x > 0)
                        {
                            // Bottom near-left pixel
                            npx = GetPixel(bmp, x - 1, y + 1);
                            SetPixel(bmp, x - 1, y + 1, ModifyColor(npx, 2.0 / 16, redError, greenError, blueError));
                        }

                        if (x > 1)
                        {
                            // Bottom far-left pixel
                            npx = GetPixel(bmp, x - 2, y + 1);
                            SetPixel(bmp, x - 2, y + 1, ModifyColor(npx, 1.0 / 16, redError, greenError, blueError));
                        }

                        if (x < bmp.PixelWidth - 1)
                        {
                            // Bottom near-right pixel
                            npx = GetPixel(bmp, x + 1, y + 1);
                            SetPixel(bmp, x + 1, y + 1, ModifyColor(npx, 2.0 / 16, redError, greenError, blueError));
                        }

                        if (x < bmp.PixelWidth - 2)
                        {
                            // Bottom far-right pixel
                            npx = GetPixel(bmp, x + 2, y + 1);
                            SetPixel(bmp, x + 2, y + 1, ModifyColor(npx, 1.0 / 16, redError, greenError, blueError));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Performs Stucki dithering on the specified bitmap's data.
        /// </summary>
        /// <param name="bmp"></param>
        /// <remarks>
        /// (1/42)
        ///         *   8   4
        /// 2   4   8   4   2
        /// 1   2   4   2   1
        /// </remarks>
        public static void Stucki(WriteableBitmap bmp)
        {
            for (int y = 0; y < bmp.PixelHeight; y++)
            {
                for (int x = 0; x < bmp.PixelWidth; x++)
                {
                    var px = GetPixel(bmp, x, y);
                    var modPx = Downsample(px);

                    SetPixel(bmp, x, y, modPx);

                    var redError = px.R - modPx.R;
                    var greenError = px.G - modPx.G;
                    var blueError = px.B - modPx.B;

                    Color npx;
                    if (x < bmp.PixelWidth - 1)
                    {
                        // Near-right pixel
                        npx = GetPixel(bmp, x + 1, y);
                        SetPixel(bmp, x + 1, y, ModifyColor(npx, 8.0 / 42, redError, greenError, blueError));
                    }
                    if (x < bmp.PixelWidth - 2)
                    {
                        // Far-right pixel
                        npx = GetPixel(bmp, x + 2, y);
                        SetPixel(bmp, x + 2, y, ModifyColor(npx, 4.0 / 42, redError, greenError, blueError));
                    }
                    if (y < bmp.PixelHeight - 1)
                    {
                        // Near-bottom pixel
                        npx = GetPixel(bmp, x, y + 1);
                        SetPixel(bmp, x, y + 1, ModifyColor(npx, 8.0 / 42, redError, greenError, blueError));

                        if (x > 0)
                        {
                            // Near-bottom near-left pixel
                            npx = GetPixel(bmp, x - 1, y + 1);
                            SetPixel(bmp, x - 1, y + 1, ModifyColor(npx, 4.0 / 42, redError, greenError, blueError));
                        }

                        if (x > 1)
                        {
                            // Near-bottom far-left pixel
                            npx = GetPixel(bmp, x - 2, y + 1);
                            SetPixel(bmp, x - 2, y + 1, ModifyColor(npx, 2.0 / 42, redError, greenError, blueError));
                        }

                        if (x < bmp.PixelWidth - 1)
                        {
                            // Near-bottom near-right pixel
                            npx = GetPixel(bmp, x + 1, y + 1);
                            SetPixel(bmp, x + 1, y + 1, ModifyColor(npx, 4.0 / 42, redError, greenError, blueError));
                        }

                        if (x < bmp.PixelWidth - 2)
                        {
                            // Near-bottom far-right pixel
                            npx = GetPixel(bmp, x + 2, y + 1);
                            SetPixel(bmp, x + 2, y + 1, ModifyColor(npx, 2.0 / 42, redError, greenError, blueError));
                        }
                    }
                    if (y < bmp.PixelHeight - 2)
                    {
                        // Far-bottom pixel
                        npx = GetPixel(bmp, x, y + 2);
                        SetPixel(bmp, x, y + 2, ModifyColor(npx, 4.0 / 42, redError, greenError, blueError));

                        if (x > 0)
                        {
                            // Far-bottom near-left pixel
                            npx = GetPixel(bmp, x - 1, y + 2);
                            SetPixel(bmp, x - 1, y + 2, ModifyColor(npx, 2.0 / 42, redError, greenError, blueError));
                        }

                        if (x > 1)
                        {
                            // Far-bottom far-left pixel
                            npx = GetPixel(bmp, x - 2, y + 2);
                            SetPixel(bmp, x - 2, y + 2, ModifyColor(npx, 1.0 / 42, redError, greenError, blueError));
                        }

                        if (x < bmp.PixelWidth - 1)
                        {
                            // Far-bottom near-right pixel
                            npx = GetPixel(bmp, x + 1, y + 2);
                            SetPixel(bmp, x + 1, y + 2, ModifyColor(npx, 2.0 / 42, redError, greenError, blueError));
                        }

                        if (x < bmp.PixelWidth - 2)
                        {
                            // Far-bottom far-right pixel
                            npx = GetPixel(bmp, x + 2, y + 2);
                            SetPixel(bmp, x + 2, y + 2, ModifyColor(npx, 1.0 / 42, redError, greenError, blueError));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Performs Floyd-Steinberg dithering on the specified bitmap's data.
        /// </summary>
        /// <param name="bmp"></param>
        /// <remarks>
        /// (1/16)
        ///     *   7
        /// 3   5   1
        /// </remarks>
        public static void FloydSteinberg(WriteableBitmap bmp)
        {
            for (int y = 0; y < bmp.PixelHeight; y++)
            {
                for (int x = 0; x < bmp.PixelWidth; x++)
                {
                    var px = GetPixel(bmp, x, y);
                    var modPx = Downsample(px);

                    SetPixel(bmp, x, y, modPx);

                    var redError = px.R - modPx.R;
                    var greenError = px.G - modPx.G;
                    var blueError = px.B - modPx.B;

                    Color npx;
                    if (x < bmp.PixelWidth - 1)
                    {
                        // Right pixel
                        npx = GetPixel(bmp, x + 1, y);
                        SetPixel(bmp, x + 1, y, ModifyColor(npx, 7.0 / 16, redError, greenError, blueError));
                    }
                    if (y < bmp.PixelHeight - 1)
                    {
                        // Bottom pixel
                        npx = GetPixel(bmp, x, y + 1);
                        SetPixel(bmp, x, y + 1, ModifyColor(npx, 5.0 / 16, redError, greenError, blueError));

                        if (x > 0)
                        {
                            // Bottom left pixel
                            npx = GetPixel(bmp, x - 1, y + 1);
                            SetPixel(bmp, x - 1, y + 1, ModifyColor(npx, 3.0 / 16, redError, greenError, blueError));
                        }

                        if (x < bmp.PixelWidth - 1)
                        {
                            // Bottom right pixel
                            npx = GetPixel(bmp, x + 1, y + 1);
                            SetPixel(bmp, x + 1, y + 1, ModifyColor(npx, 1.0 / 16, redError, greenError, blueError));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Takes a color and returns the closest 16bpp (RGB565) one.
        /// </summary>
        /// <param name="orig"></param>
        /// <returns></returns>
        static Color Downsample(Color orig)
        {
            var mod = orig;
            mod.R = (byte)(Math.Round(mod.R * 31.0 / 255) * 255 / 31);
            mod.G = (byte)(Math.Round(mod.G * 63.0 / 255) * 255 / 63);
            mod.B = (byte)(Math.Round(mod.B * 31.0 / 255) * 255 / 31);
            return mod;
        }

        /// <summary>
        /// Modifies a color with the specified delta ratio and RGB error levels.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="ratio"></param>
        /// <param name="redError"></param>
        /// <param name="greenError"></param>
        /// <param name="blueError"></param>
        /// <returns></returns>
        static Color ModifyColor(Color color, double ratio, int redError, int greenError, int blueError)
        {
            // Red
            var delta = ratio * redError;
            if (color.R + delta < 0) color.R = 0;
            else if (color.R + delta > 255) color.R = 255;
            else color.R = (byte)Math.Floor(color.R + delta);

            // Green
            delta = ratio * greenError;
            if (color.G + delta < 0) color.G = 0;
            else if (color.G + delta > 255) color.G = 255;
            else color.G = (byte)Math.Floor(color.G + delta);

            // Blue
            delta = ratio * blueError;
            if (color.B + delta < 0) color.B = 0;
            else if (color.B + delta > 255) color.B = 255;
            else color.B = (byte)Math.Floor(color.B + delta);

            return color;
        }

        /// <summary>
        /// Gets the ARGB color of the specified pixel.
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static Color GetPixel(WriteableBitmap bmp, int x, int y)
        {
            var idx = y * bmp.PixelWidth + x;
            var argb = bmp.Pixels[idx];
            var alpha = argb >> 24;
            var red = argb >> 16 & 0xff;
            var green = argb >> 8 & 0xff;
            var blue = argb & 0xff;

            return Color.FromArgb((byte)alpha, (byte)red, (byte)green, (byte)blue);
        }

        /// <summary>
        /// Sets the ARGB color of the specified pixel.
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="pixel"></param>
        static void SetPixel(WriteableBitmap bmp, int x, int y, Color pixel)
        {
            var idx = y * bmp.PixelWidth + x;
            var newRgb = pixel.A << 24 | pixel.R << 16 | pixel.G << 8 | pixel.B;
            bmp.Pixels[idx] = newRgb;
        }

    }
}
