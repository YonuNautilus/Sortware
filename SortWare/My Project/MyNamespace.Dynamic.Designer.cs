using System;
using System.ComponentModel;
using System.Diagnostics;

namespace SortWare.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {

            [EditorBrowsable(EditorBrowsableState.Never)]
            public ConvDirTypeSelector m_ConvDirTypeSelector;

            public ConvDirTypeSelector ConvDirTypeSelector
            {
                [DebuggerHidden]
                get
                {
                    m_ConvDirTypeSelector = Create__Instance__(m_ConvDirTypeSelector);
                    return m_ConvDirTypeSelector;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_ConvDirTypeSelector))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_ConvDirTypeSelector);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public DecompressFolderDialog m_DecompressFolderDialog;

            public DecompressFolderDialog DecompressFolderDialog
            {
                [DebuggerHidden]
                get
                {
                    m_DecompressFolderDialog = Create__Instance__(m_DecompressFolderDialog);
                    return m_DecompressFolderDialog;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DecompressFolderDialog))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DecompressFolderDialog);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public DupeChecker m_DupeChecker;

            public DupeChecker DupeChecker
            {
                [DebuggerHidden]
                get
                {
                    m_DupeChecker = Create__Instance__(m_DupeChecker);
                    return m_DupeChecker;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DupeChecker))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DupeChecker);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public MainInterface m_MainInterface;

            public MainInterface MainInterface
            {
                [DebuggerHidden]
                get
                {
                    m_MainInterface = Create__Instance__(m_MainInterface);
                    return m_MainInterface;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_MainInterface))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_MainInterface);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public PropertiesViewerInterface m_PropertiesViewerInterface;

            public PropertiesViewerInterface PropertiesViewerInterface
            {
                [DebuggerHidden]
                get
                {
                    m_PropertiesViewerInterface = Create__Instance__(m_PropertiesViewerInterface);
                    return m_PropertiesViewerInterface;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_PropertiesViewerInterface))
                        return;
                    if (value is not null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_PropertiesViewerInterface);
                }
            }

        }


    }
}