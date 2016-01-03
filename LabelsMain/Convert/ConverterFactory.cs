using System;
using LabelsMain.Factory;
using LabelsMain.Models;

namespace LabelsMain.Convert
{
    internal class ConverterFactory
    {
        public static IConverter Create(LabelType type)
        {
            switch (type)
            {
                case LabelType.Zebra:
                    return new ZebraConverter();
                case LabelType.Intermec:
                    return new IntermecConverter();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}