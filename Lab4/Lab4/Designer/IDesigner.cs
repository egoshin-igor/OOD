using System.Collections.Generic;

namespace Lab4.Designer
{
    interface IDesigner
    {
        PictureDraft CreateDraft( List<string> shapeDescriptions );
    }
}
