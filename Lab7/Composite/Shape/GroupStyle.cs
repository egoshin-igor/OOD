﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Composite.Shape
{
    public class GroupStyle : IStyle
    {
        protected readonly IEnumerable<IStyle> _styles;

        public bool IsEnabled
        {
            get
            {
                List<IStyle> styles = _styles.ToList();
                if ( styles.Count == 0 )
                {
                    return true;
                }

                IStyle firstStyle = styles.First();
                return styles.All( s => s.IsEnabled == firstStyle.IsEnabled );
            }
        }

        public Color Color
        {
            get
            {
                List<IStyle> styles = _styles.ToList();
                if ( styles.Count == 0 )
                {
                    return Color.Empty;
                }

                IStyle firstStyle = styles.First();
                return styles.All( s => s.Color == firstStyle.Color ) ? firstStyle.Color : Color.Empty;
            }
            set
            {
                foreach ( IStyle style in _styles )
                {
                    style.Color = value;
                }
            }
        }

        public GroupStyle( IEnumerable<IStyle> styles )
        {
            _styles = styles ?? new List<IStyle>();
        }

        public void Enable( bool enable )
        {
            foreach ( IStyle style in _styles )
            {
                style.Enable( enable );
            }
        }
    }
}
