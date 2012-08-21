#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;

#endregion

namespace SourceLineCounter
{
    internal class GraphItem
    {
        public GraphItem(string label, int amount)
        {
            Label = label;
            Amount = amount;
        }

        public string Label { get; private set; }
        public int Amount { get; private set; }
    }

    internal class PieChart
    {
        private readonly Dictionary<GraphItem, Color> _itemColors = new Dictionary<GraphItem, Color>();
        private readonly List<GraphItem> _items = new List<GraphItem>();

        public void Add(GraphItem item)
        {
            if (_items.Find(x => x.Label == item.Label) == null)
            {
                _items.Add(item);
            }
        }

        public void Remove(GraphItem item)
        {
            _items.Remove(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public Color GetColor(GraphItem item)
        {
            return _itemColors[item];
        }

        public Bitmap Draw(Size canvasSize, Size chartSize, Point chartPosition, Point legendOffset, Size legendIndicatorSize, Font legendFont, IEnumerable<Color> primaryColors = null)
        {
            var chartBitmap = new Bitmap(canvasSize.Width, canvasSize.Height);

            using (var chartGraphics = Graphics.FromImage(chartBitmap))
            {
                chartGraphics.SmoothingMode = SmoothingMode.HighQuality;
                chartGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                chartGraphics.CompositingQuality = CompositingQuality.HighQuality;
                chartGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                chartGraphics.SmoothingMode = SmoothingMode.HighQuality;
                chartGraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;

                var rect = new Rectangle(chartPosition, chartSize);

                // populate key colors
                var colors = new List<Color>();
                if (primaryColors != null)
                    colors.AddRange(primaryColors);
                colors.AddRange(RandomUniqueColors(_items.Count - colors.Count));

                _itemColors.Clear();

                _items.Sort((k1, k2) => k2.Amount.CompareTo(k1.Amount));

                var newlineArray = new[] {Environment.NewLine};

                const int keyPadding = 3;
                var keyPosition = new Point(chartPosition.X + chartSize.Width + legendOffset.X, Math.Max(legendOffset.Y, keyPadding));

                using (var textBrush = new SolidBrush(Color.Black))
                {
                    var startAngle = 0.0f;

                    for (var i = 0; i < _items.Count; i++)
                    {
                        var item = _items[i];

                        var color = colors[i];

                        _itemColors[item] = color;

                        using (var sectorBrush = new SolidBrush(color))
                        {
                            var amountTotal = _items.Sum(x => x.Amount);

                            // draw graph sector
                            var sweepAngle = (item.Amount/(float) amountTotal)*360;
                            chartGraphics.FillPie(sectorBrush, rect, startAngle, sweepAngle);
                            startAngle += sweepAngle;

                            var textSize = chartGraphics.MeasureString(item.Label, legendFont);

                            // measure newline strings
                            if (item.Label.Split(newlineArray, StringSplitOptions.None).Length > 1)
                                textSize.Height *= 2;

                            // todo fix keys drawn off canvas y-axis

                            // draw key indicator
                            chartGraphics.FillEllipse(sectorBrush, keyPosition.X, keyPosition.Y, legendIndicatorSize.Width, legendIndicatorSize.Height);

                            // draw key text
                            chartGraphics.DrawString(string.Format("{0} ({1:0.0}%)", item.Label, (item.Amount/(float) amountTotal)*100),
                                legendFont,
                                textBrush,
                                keyPosition.X + legendIndicatorSize.Width + keyPadding,
                                keyPosition.Y - (legendIndicatorSize.Height/2) + keyPadding);

                            keyPosition.Y += (int) textSize.Height + keyPadding;
                        }
                    }
                }
            }

            return chartBitmap;
        }

        private static IEnumerable<Color> RandomUniqueColors(int count)
        {
            if (count > 0)
            {
                var colors = new Color[count];
                var hs = new Dictionary<Color, bool>();

                var r = new Random();

                for (var i = 0; i < count; i++)
                {
                    Color color;
                    while (hs.ContainsKey(color = Color.FromArgb(r.Next(70, 200), r.Next(100, 225), r.Next(100, 230))))
                    {
                    }

                    hs.Add(color, true);
                    colors[i] = color;
                }

                return colors;
            }

            return new Color[] {};
        }
    }
}