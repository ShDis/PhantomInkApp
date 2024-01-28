using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhantomInkApp
{
    public class MediumCard : IComparable<MediumCard>
    {
        public MediumCard(string title, string question) 
        { 
            this.title = title;
            this.question = question;
        }
        private string title;
        public string Title { get { return title; } }
        private string question;
        public string Question { get { return question; } }

        public int CompareTo(MediumCard? other)
        {
            if (other == null)
                return 1;
            if (this.title == other.Title && this.question == other.Question)
                return 0;
            return -1;
        }
    }
}
