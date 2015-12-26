using System;
using System.Data.Entity;
using LabelsMain.Models;

namespace LabelsMain.Factory
{
    public class LabelFactory
    {
        public static ILabelFactory Create(LabelType type)
        {
            switch (type)
            {
                case LabelType.Zebra:
                    return new ZebraFactory();
                case LabelType.Intermec:
                    return new IntermecFactory();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
