﻿namespace Adapter.ModernGrapicsLib
{
    public class RGBAColor
    {
        public float R { get; }
        public float G { get; }
        public float B { get; }
        public float A { get; }

        public RGBAColor( float r, float g, float b, float a )
        {
            if ( !IsValidRGBAComponent( r ) || !IsValidRGBAComponent( g ) || !IsValidRGBAComponent( b ) || !IsValidRGBAComponent( a ) )
            {
                throw new GraphicsLogicalException( $"RGBA components must be beetwen 0 and 1" );
            }

            R = r;
            G = g;
            B = b;
            A = a;
        }

        private bool IsValidRGBAComponent( float number )
        {
            if ( number < 0 || number > 1 )
            {
                return false;
            }

            return true;
        }
    }
}
