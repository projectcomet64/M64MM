/*
 * Licensed under MIT by: Lea Hayes
 * https://www.codeproject.com/Articles/25471/Customizable-ComboBox-Drop-Down?fid=1244083&df=90&mpp=25&sort=Position&spc=Relaxed&prof=True&view=Normal&fr=26#xx0xx
 * https://opensource.org/licenses/mit-license.php
 *
 */

using System;

namespace M64MM2.Controls.CustomCombobox
{
    public class OldNewEventArgs<T> : EventArgs
    {
        public OldNewEventArgs(T oldValue, T newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        public T OldValue
        {
            get { return this.m_oldValue; }
            protected set { this.m_oldValue = value; }
        }
        public T NewValue
        {
            get { return this.m_newValue; }
            protected set { this.m_newValue = value; }
        }

        T m_oldValue = default(T);
        T m_newValue = default(T);
    }

    public delegate void OldNewEventHandler<T>(object sender, OldNewEventArgs<T> e);
}
