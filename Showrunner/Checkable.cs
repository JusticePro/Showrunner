using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showrunner
{
    /***
     * This interface is shared by Show and Episode. It allows ControlNotepad to update the note variable when it is no longer in focus.
     */
    public interface Checkable
    {
        void updateToDo(string name, Dictionary<string, bool> values); // Dictionary = name of task : done or not
    }
}
