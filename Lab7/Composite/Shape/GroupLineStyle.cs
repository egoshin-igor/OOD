using System.Collections.Generic;
using System.Linq;

namespace Composite.Shape
{
    class GroupLineStyle : GroupStyle, ILineStyle
    {
        public float Thickness// ширина не 0
        {
            get
            {
                if ( _styles.Count() == 0 )
                {
                    return 0;
                }

                IEnumerable<ILineStyle> lineStyles = _styles.Select( s => s as ILineStyle );
                ILineStyle firstStyle = lineStyles.First();
                return lineStyles.All( s => s.Thickness == firstStyle.Thickness ) ? firstStyle.Thickness : 0;
            }
            set
            {

            }
        }

        public GroupLineStyle( IEnumerable<ILineStyle> styles )
            : base( styles )
        {
        }
    }
}
