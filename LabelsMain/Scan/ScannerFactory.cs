using System;
using LabelsMain.Models;

namespace LabelsMain.Scan
{
    public class ScannerFactory
    {
        public static IScanner Create(LabelType type)
        {
            switch (type)
            {
                case LabelType.Zebra:
                    return new ZebraScanner();
                case LabelType.Intermec:
                    return new IntermecScanner();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
