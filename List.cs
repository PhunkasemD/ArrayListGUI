using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collections;

namespace Lists
    {
        public interface List : Collection
        {
            void add(int index, object e);
            void remove(int index);
            object get(int index);
            void set(int index, object e);
            int indexOf(object e);
        }
    
    }
