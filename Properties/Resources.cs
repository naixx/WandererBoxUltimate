// Decompiled with JetBrains decompiler
// Type: ASCOM.WandererBoxes.Properties.Resources
// Assembly: ASCOM.WandererBoxes.Switch, Version=6.6.0.0, Culture=neutral, PublicKeyToken=5a596dde3293c610
// MVID: E3106A5C-05F3-42C7-89F9-2A2C7253BE13
// Assembly location: C:\Program Files (x86)\Wanderer Astro\ASCOM.WandererBoxes.Switch.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ASCOM.WandererBoxes.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (Resources.resourceMan == null)
          Resources.resourceMan = new ResourceManager("ASCOM.WandererBoxes.Properties.Resources", typeof (Resources).Assembly);
        return Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Resources.resourceCulture;
      set => Resources.resourceCulture = value;
    }

    internal static Bitmap ASCOM
    {
      get => (Bitmap) Resources.ResourceManager.GetObject(nameof (ASCOM), Resources.resourceCulture);
    }

    internal static Icon DefaultIcon
    {
      get
      {
        return (Icon) Resources.ResourceManager.GetObject(nameof (DefaultIcon), Resources.resourceCulture);
      }
    }
  }
}
