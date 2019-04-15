namespace Adapter.ModernGrapicsLib
{
    class RGBAColor
    {
        public float R { get; }
        public float G { get; }
        public float B { get; }
        public float A { get; }

        public RGBAColor( float r, float g, float b, float a )
        {
            if ( !IsValid( r ) || !IsValid( g ) || !IsValid( b ) || !IsValid( a ) )
            {
                throw new GraphicsLogicalException( $"RGBA numbers can be beetwen 0 and 1" );
            }

            R = r;
            G = g;
            B = b;
            A = a;
        }

        private bool IsValid( float number )
        {
            if ( number < 0 || number > 1 )
            {
                return false;
            }

            return true;
        }
    }
}
