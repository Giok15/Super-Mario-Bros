using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
    class ButtonLevel
    {
        public Image imgLevel;
        private Image imgBezet;
        private Image imgBehaald;
        private Image imgBezig;

        public enum Status {
            bezet,
            bezig,
            behaald
        }

       public Status status = Status.bezet;

        public ButtonLevel(Image imgBezet, Image imgBehaald, Image imgBezig)
        {
            this.imgBezet = imgBezet;
            this.imgBehaald = imgBehaald;
            this.imgBezig = imgBezig;

            imgLevel = imgBezet;
            status = Status.bezet;
        }

        public void LevelGehaald()
        {
            imgLevel = imgBehaald;
            status = Status.behaald;
        }

        public void LevelBezig()
        {
            imgLevel = imgBezig;
            status = Status.bezig;
        }
    }
}
