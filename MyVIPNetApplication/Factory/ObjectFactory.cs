using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyVIPNetApplication.Factory
{
    public class ObjectFactory
    {
        private static string IRaceTypeConfig = ConfigurationManager.AppSettings["IRaceTypeConfig"];

        public static IRace CreateRaceConfig()
        {
            RaceType racetype = (RaceType)Enum.Parse(typeof(RaceType), IRaceTypeConfig);

            IRace race = null;
            switch (racetype)
            {
                case RaceType.Human:
                    race = new Human();
                    break;
            }

            return race;
        }

    }

    public enum RaceType
    {
        Human = 1,
        ORC = 2,
        NC = 3,
        Undead = 4
    }


}
