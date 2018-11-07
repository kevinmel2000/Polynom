using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;                                   
                                                                
namespace FunctionStudy                                         
{                                                               
    class Section                                               
    {                                                           
        public double Left { get; private set; }
        public double Right { get; private set; }

        public Section(double left, double right)
        {
            Left = left;
            Right = right;
        }
    }
}
