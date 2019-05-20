using System.Collections.Generic;
using System.Linq;

namespace Composite.Shape
{
    class GroupLineStyle : GroupStyle, ILineStyle
    {
        public float Thickness
        {
            get
            {
                List<IStyle> styles = _styles.ToList();
                if ( styles.Count == 0 )
                {
                    return 0;
                }

                IEnumerable<ILineStyle> lineStyles = styles.Select( s => s as ILineStyle );
                ILineStyle firstStyle = lineStyles.First();
                return lineStyles.All( s => s.Thickness == firstStyle.Thickness ) ? firstStyle.Thickness : 0;
            }
            set
            {
                IEnumerable<ILineStyle> lineStyles = _styles.Select( s => s as ILineStyle );
                foreach ( ILineStyle style in lineStyles )
                {
                    style.Thickness = value;
                }
            }
        }

        public GroupLineStyle( IEnumerable<ILineStyle> styles )
            : base( styles )
        {
        }
    }
}
