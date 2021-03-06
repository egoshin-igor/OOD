﻿using System;
using System.Globalization;
using System.IO;
using Adapter.GraphicsLib;
using Adapter.ModernGrapicsLib;
using Adapter.Util;

namespace Adapter.Adapter
{
    public class ModernGrapicsClassAdapter : ModernGraphicsRenderer, ICanvas
    {
        private Point _startPosition = new Point( 0, 0 );
        private RGBAColor _rgbaColor = new RGBAColor( 0, 0, 0, 0 );

        public ModernGrapicsClassAdapter( TextWriter output )
            : base( output )
        {
        }

        public void LineTo( int x, int y )
        {
            Point newPosition = new Point( x, y );
            DrawLine( _startPosition, newPosition, _rgbaColor );
            _startPosition = newPosition;
        }

        public void MoveTo( int x, int y )
        {
            _startPosition = new Point( x, y );
        }

        public void SetColor( uint rgbColor )
        {
            _rgbaColor = RGBAConverter.Convert( rgbColor );
        }


    }
}
