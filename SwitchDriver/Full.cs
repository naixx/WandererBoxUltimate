using ScottPlot;

namespace ASCOM.WandererBoxes
{
    public class Full : IAxisLimitManager
    {
        /// <summary>
        /// Defines the amount of whitespace added to the right of the data when data runs outside the current view.
        /// 1.0 for a view that tightly fits the data and is always changing.
        /// 2.0 for a view that doubles the horizontal span when new data runs outside the current view.
        /// </summary>
        public double ExpansionRatio { get; set; } = .25;

        public CoordinateRange GetRangeX(CoordinateRange viewRangeX, CoordinateRange dataRangeX)
        {
            bool rightEdgeIsTooClose = viewRangeX.Max < dataRangeX.Max;
            bool rightEdgeIsTooFar = viewRangeX.Max > dataRangeX.Max + dataRangeX.Span;
            bool replaceRight = rightEdgeIsTooClose || rightEdgeIsTooFar;
            double xMax = replaceRight
                ? dataRangeX.Max + dataRangeX.Span * ExpansionRatio
                : viewRangeX.Max;

            return new CoordinateRange(dataRangeX.Min, xMax);
        }

        public CoordinateRange GetRangeY(CoordinateRange viewRangeY, CoordinateRange dataRangeY)
        {
            return viewRangeY;
        }
    }
}