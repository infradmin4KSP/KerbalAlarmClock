using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP;
using KSPPluginFramework;

namespace KerbalAlarmClock
{
    /// <summary>
    /// A class to store the UT of events and get back useful data
    /// </summary>
//    public class KACTime
//    {

//        //really there are 31,446,925.9936 seconds in a year, use 365*24 so the reciprocal math 
//        //to go to years and get back to full days isn't confusing - have to sort this out some day though.
//        //NOTE: KSP Dates appear to all be 365 * 24 as well - no fractions - woohoo
//        const double HoursPerDayEarth = 24;
//        const double HoursPerYearEarth = 365 * HoursPerDayEarth;

//        const double HoursPerDayKerbin = 6;
//        const double HoursPerYearKerbin = 426 * HoursPerDayKerbin;

//        #region "Constructors"
//        public KACTime()
//        { }
//        public KACTime(double NewUT)
//        {
//            UT = NewUT;
//        }
//        public KACTime(double Years, double Days, double Hours, double Minutes, double Seconds)
//        {
//            UT = KACTime.BuildUTFromRaw(Years, Days, Hours, Minutes, Seconds);
//        }
//        #endregion

//        /// <summary>
//        /// Build the UT from raw values
//        /// </summary>
//        /// <param name="Years"></param>
//        /// <param name="Days"></param>
//        /// <param name="Hours"></param>
//        /// <param name="Minutes"></param>
//        /// <param name="Seconds"></param>
//        public void BuildUT(double Years, double Days, double Hours, double Minutes, double Seconds)
//        {
//            UT = KACTime.BuildUTFromRaw(Years, Days, Hours, Minutes, Seconds);
//        }

//        public void BuildUT(String Years, String Days, String Hours, String Minutes, String Seconds)
//        {
//            BuildUT(Convert.ToDouble(Years), Convert.ToDouble(Days), Convert.ToDouble(Hours), Convert.ToDouble(Minutes), Convert.ToDouble(Seconds));
//        }

//        #region "Properties"

//        //Stores the Universal Time in game seconds
//        public double UT;

//        //readonly props that resolve from UT
//        public long Second
//        {
//            get { return Convert.ToInt64(Math.Truncate(UT % 60)); }
//        }
//        public long Minute
//        {
//            get { return Convert.ToInt64(Math.Truncate((UT / 60) % 60)); }
//        }

//        private double HourRaw { get { return UT / 60 / 60; } }

//        public long Hour
//        {
//            get {
//                if (GameSettings.KERBIN_TIME) {
//                    return Convert.ToInt64(Math.Truncate(HourRaw % HoursPerDayKerbin));
//                } else {
//                    return Convert.ToInt64(Math.Truncate(HourRaw % HoursPerDayEarth));
//                }
//            }
//        }

//        public long Day
//        {
//            get {
//                if (GameSettings.KERBIN_TIME) {
//                    return Convert.ToInt64(Math.Truncate(((HourRaw % HoursPerYearKerbin) / HoursPerDayKerbin)));
//                } else {
//                    return Convert.ToInt64(Math.Truncate(((HourRaw % HoursPerYearEarth) / HoursPerDayEarth)));
//                }
//            }
//        }

//        public long Year
//        {
//            get {
//                if (GameSettings.KERBIN_TIME) {
//                    return Convert.ToInt64(Math.Truncate((HourRaw / HoursPerYearKerbin)));
//                } else {
//                    return Convert.ToInt64(Math.Truncate((HourRaw / HoursPerYearEarth)));
//                }
//            }
//        }
//        //public long HourKerbin
//        //{
//        //    get { return Convert.ToInt64(Math.Truncate(HourRaw % HoursPerDayKerbin)); }
//        //}

//        //public long DayKerbin
//        //{
//        //    get { return Convert.ToInt64(Math.Truncate(((HourRaw % HoursPerYearKerbin) / HoursPerDayKerbin))); }
//        //}

//        //public long YearKerbin
//        //{
//        //    get { return Convert.ToInt64(Math.Truncate((HourRaw / HoursPerYearKerbin))); }
//        //}        
//        #endregion

//        #region "String Formatting"
//        public String IntervalString()
//        {
//            return IntervalString(6);
//        }
//        public String IntervalString(int segments)
//        {
//            String strReturn = "";

//            if (UT < 0) strReturn += "+ ";

//            int intUsed = 0;

//            if (intUsed < segments && Year != 0)
//            {
//                strReturn += String.Format("{0}y", Math.Abs(Year));
//                intUsed++;
//            }

//            if (intUsed < segments && (Day != 0 || intUsed > 0))
//            {
//                if (intUsed > 0) strReturn += ", ";
//                strReturn += String.Format("{0}d", Math.Abs(Day));
//                intUsed++;
//            }

//            if (intUsed < segments && (Hour != 0 || intUsed > 0))
//            {
//                if (intUsed > 0) strReturn += ", ";
//                strReturn += String.Format("{0}h", Math.Abs(Hour));
//                intUsed++;
//            }
//            if (intUsed < segments && (Minute != 0 || intUsed > 0))
//            {
//                if (intUsed > 0) strReturn += ", ";
//                strReturn += String.Format("{0}m", Math.Abs(Minute));
//                intUsed++;
//            }
//            if (intUsed < segments)// && (Second != 0 || intUsed > 0))
//            {
//                if (intUsed > 0) strReturn += ", ";
//                strReturn += String.Format("{0}s", Math.Abs(Second));
//                intUsed++;
//            }


//            return strReturn;
//        }

//        public String IntervalDateTimeString()
//        {
//            return IntervalDateTimeString(6);
//        }
//        public String IntervalDateTimeString(int segments)
//        {
//            String strReturn = "";

//            if (UT < 0) strReturn += "+ ";

//            int intUsed = 0;

//            if (intUsed < segments && Year != 0)
//            {
//                strReturn += String.Format("{0}y", Math.Abs(Year));
//                intUsed++;
//            }

//            if (intUsed < segments && (Day != 0 || intUsed > 0))
//            {
//                if (intUsed > 0) strReturn += ", ";
//                strReturn += String.Format("{0}d", Math.Abs(Day));
//                intUsed++;
//            }

//            if (intUsed < segments && (Hour != 0 || intUsed > 0))
//            {
//                if (intUsed > 0) strReturn += ", ";
//                strReturn += String.Format("{0:00}", Math.Abs(Hour));
//                intUsed++;
//            }
//            if (intUsed < segments && (Minute != 0 || intUsed > 0))
//            {
//                if (intUsed > 0) strReturn += ":";
//                strReturn += String.Format("{0:00}", Math.Abs(Minute));
//                intUsed++;
//            }
//            if (intUsed < segments)// && (Second != 0 || intUsed > 0))
//            {
//                if (intUsed > 0) strReturn += ":";
//                strReturn += String.Format("{0:00}", Math.Abs(Second));
//                intUsed++;
//            }


//            return strReturn;
//        }

//        public String DateString()
//        {
//            return String.Format("Year {0},Day {1}, {2}h, {3}m, {4}s", Year + 1, Day + 1, Hour, Minute, Second);
//        }

//        public String DateTimeString()
//        {
//            return String.Format("Year {0},Day {1}, {2:00}:{3:00}:{4:00}", Year + 1, Day + 1, Hour, Minute, Second);
//        }

//        public String IntervalStringLong()
//        {
//            String strReturn = "";
//            if (UT < 0) strReturn += "+ ";
//            strReturn += String.Format("{0} Years, {1} Days, {2:00}:{3:00}:{4:00}", Math.Abs(Year), Math.Abs(Day), Math.Abs(Hour), Math.Abs(Minute), Math.Abs(Second));
//            return strReturn;
//        }

//        public String UTString()
//        {
//            String strReturn = "";
//            if (UT < 0) strReturn += "+ ";
//            strReturn += String.Format("{0:N0}s", Math.Abs(UT));
//            return strReturn;
//        }
//        #endregion

//        public override String ToString()
//        {
//            return IntervalStringLong();
//        }

//        #region Static Properties
//        public static Double HoursPerDay { get { return GameSettings.KERBIN_TIME ? HoursPerDayKerbin : HoursPerDayEarth; } }
//        public static Double SecondsPerDay { get { return HoursPerDay * 60 * 60; } }
//        public static Double HoursPerYear { get { return GameSettings.KERBIN_TIME ? HoursPerYearKerbin : HoursPerYearEarth; } }
//        public static Double DaysPerYear { get { return HoursPerYear / HoursPerDay; } }
//        public static Double SecondsPerYear { get { return HoursPerYear * 60 * 60; } }
//        #endregion

//        #region "Static Functions"
//        //fudging for dates
//        public static KACTime timeDateOffest = new KACTime(1, 1, 0, 0, 0);

//        public static Double BuildUTFromRaw(String Years, String Days, String Hours, String Minutes, String Seconds)
//        {
//            return BuildUTFromRaw(Convert.ToDouble(Years), Convert.ToDouble(Days), Convert.ToDouble(Hours), Convert.ToDouble(Minutes), Convert.ToDouble(Seconds));
//        }
//        public static Double BuildUTFromRaw(double Years, double Days, double Hours, double Minutes, double Seconds)
//        {
//            if (GameSettings.KERBIN_TIME)
//            {
//                return Seconds +
//                   Minutes * 60 +
//                   Hours * 60 * 60 +
//                   Days * HoursPerDayKerbin * 60 * 60 +
//                   Years * HoursPerYearKerbin * 60 * 60;
//            }
//            else
//            {
//                return Seconds +
//                   Minutes * 60 +
//                   Hours * 60 * 60 +
//                   Days * HoursPerDayEarth * 60 * 60 +
//                   Years * HoursPerYearEarth * 60 * 60;
//            }
//        }

//        public static String PrintInterval(KACTime timeTemp, OldPrintTimeFormat TimeFormat)
//        {
//            return PrintInterval(timeTemp, 3, TimeFormat);
//        }

//        public static String PrintInterval(KACTime timeTemp, int Segments, OldPrintTimeFormat TimeFormat)
//        {
//            switch (TimeFormat )
//            {
//                case OldPrintTimeFormat.TimeAsUT:
//                    return timeTemp.UTString();
//                case OldPrintTimeFormat.KSPString:
//                    return timeTemp.IntervalString(Segments);
//                case OldPrintTimeFormat.DateTimeString:
//                    return timeTemp.IntervalDateTimeString(Segments);
//                default:
//                    return timeTemp.IntervalString(Segments);
//            }
//        }

//        public static String PrintDate(KACTime timeTemp, OldPrintTimeFormat TimeFormat)
//        {
//            switch (TimeFormat)
//            {
//                case OldPrintTimeFormat.TimeAsUT:
//                    return timeTemp.UTString();
//                case OldPrintTimeFormat.KSPString:
//                    return timeTemp.DateString();
//                case OldPrintTimeFormat.DateTimeString:
//                    return timeTemp.DateTimeString();
//                default:
//                    return timeTemp.DateTimeString();
//            }
//        }

//        //public enum PrintTimeFormat
//        //{
//        //    TimeAsUT,
//        //    KSPString,
//        //    DateTimeString
//        //}
//#endregion
//    }

    public enum OldPrintTimeFormat
    {
        TimeAsUT,
        KSPString,
        DateTimeString
    }

    public class KACTimeStringArray
    {
        public enum TimeEntryPrecisionEnum
        {
            Seconds = 0,
            Minutes = 1,
            Hours = 2,
            Days = 3,
            Years = 4
        }

        public TimeEntryPrecisionEnum TimeEntryPrecision { get; private set; }

        private String _Years="",_Days="",_Hours="",_Minutes="",_Seconds="";

        public String Years { get { return _Years; } set { _Years = value; SetValid(); } }
        public String Days { get { return _Days; } set { _Days = value; SetValid(); } }
        public String Hours { get { return _Hours; } set { _Hours = value; SetValid(); } }
        public String Minutes { get { return _Minutes; } set { _Minutes = value; SetValid(); } }
        public String Seconds { get { return _Seconds; } set { _Seconds = value; SetValid(); } }

        public Boolean Valid { get { return _Valid; } }
        Boolean _Valid=true;

        public KACTimeStringArray(TimeEntryPrecisionEnum LevelOfPrecision)
        {
            TimeEntryPrecision = LevelOfPrecision;
        }

        public KACTimeStringArray(Double NewUT, TimeEntryPrecisionEnum LevelOfPrecision)
            : this(LevelOfPrecision)
        {
            BuildFromUT(NewUT);
        }

        private void SetValid()
        {
            Int32 intTest;
            if (Int32.TryParse(_Years, out intTest) && Int32.TryParse(_Days, out intTest) && Int32.TryParse(_Hours, out intTest) && Int32.TryParse(_Minutes, out intTest) && Int32.TryParse(_Seconds, out intTest))
                _Valid = true;
            else
                _Valid = false;
        }

        public void BuildFromUT(Double UT)
        {
            KSPTimeSpan timeTemp = new KSPTimeSpan(UT);
            if (TimeEntryPrecision >= TimeEntryPrecisionEnum.Years)
                Years = timeTemp.Years.ToString();
            else
                Years = "0";

            if (TimeEntryPrecision > TimeEntryPrecisionEnum.Days)
                Days = timeTemp.Days.ToString();
            else if (TimeEntryPrecision == TimeEntryPrecisionEnum.Days)
                Days = ((timeTemp.Years * KSPDateStructure.DaysPerYear) + timeTemp.Days).ToString();
            else
                Days = "0";

            if (TimeEntryPrecision > TimeEntryPrecisionEnum.Hours)
                Hours = timeTemp.Hours.ToString();
            else if (TimeEntryPrecision == TimeEntryPrecisionEnum.Hours)
                Hours = ((timeTemp.Years * KSPDateStructure.HoursPerYear) + (timeTemp.Days * KSPDateStructure.HoursPerDay) + timeTemp.Hours).ToString();
            else
                Hours = "0";
            Minutes = timeTemp.Minutes.ToString();
            Seconds = timeTemp.Seconds.ToString();
        }

        public double UT
        {
            get 
            {
                if (KSPDateStructure.CalendarType == CalendarTypeEnum.Earth)
                {
                    //ZeroString(Years), 
                    Double result = new KSPTimeSpan(ZeroString(Days), ZeroString(Hours), ZeroString(Minutes), ZeroString(Seconds)).UT;
                    if (Convert.ToInt32(ZeroString(Years)) != 0)
                        result += Convert.ToInt32(ZeroString(Years)) * KSPDateStructure.SecondsPerYear;
                    return result;
                }
                else
                {
                    IDateTimeFormatter tf = KSPUtil.dateTimeFormatter;
                    Double result = tf.Year * Convert.ToInt32(ZeroString(Years)) + tf.Day * Convert.ToInt32(ZeroString(Days)) + tf.Hour * Convert.ToInt32(ZeroString(Hours)) +
                        tf.Minute * Convert.ToInt32(ZeroString(Minutes)) + Convert.ToInt32(ZeroString(Seconds));
                    return result;
                }
            
            }
        }
        private String ZeroString(String strInput)
        {
            Double dblTemp;
            if (!Double.TryParse(strInput,out dblTemp))
                return "0";
            else
                return strInput;
        }
    }


    public class KACVesselSOI
    {
        public String Name;
        public String SOIName;
        //public String SOINew;
        //public Boolean SOIChanged { get { return (SOILast != SOINew); } }

        //public KACVesselSOI() { }
        public KACVesselSOI(String VesselName, String SOIBody)
        {
            Name = VesselName;
            SOIName = SOIBody;
        }
    }

    public class KACXFerTarget
        {
            private CelestialBody _Origin;

            public CelestialBody Origin
            {
                get { return _Origin; }
                set { 
                    _Origin = value;
                    if (_Target != null)
                    {
                        CalcPhaseAngleTarget();
                        CalcPhaseAngleCurrent();
                    }
                }
            }
            private CelestialBody _Target;

            public CelestialBody Target
            {
                get { return _Target; }
                set { 
                    _Target = value;
                    if (_Target != null)
                    {
                        CalcPhaseAngleTarget();
                        CalcPhaseAngleCurrent();
                    }
                }
            }
            
            private double _PhaseAngleTarget;
            private double _PhaseAngleCurrent;
            public double PhaseAngleTarget
            {
                get
                {
                    CalcPhaseAngleTarget();
                    return KACUtils.clampDegrees(_PhaseAngleTarget); }
                }

            private void CalcPhaseAngleTarget()
            {
                _PhaseAngleTarget = KACUtils.clampDegrees360(180 * (1 - Math.Pow((Origin.orbit.semiMajorAxis + Target.orbit.semiMajorAxis) / (2 * Target.orbit.semiMajorAxis), 1.5)));
            }
            public double PhaseAngleCurrent
            {
                get
                {
                    CalcPhaseAngleCurrent2();
                    return KACUtils.clampDegrees(_PhaseAngleCurrent);
                }
            }

            private void CalcPhaseAngleCurrent()
            {
                _PhaseAngleCurrent = KACUtils.clampDegrees360(Target.orbit.trueAnomaly + Target.orbit.argumentOfPeriapsis +
                    Target.orbit.LAN - (Origin.orbit.trueAnomaly + Origin.orbit.argumentOfPeriapsis + Origin.orbit.LAN));
            }
            private void CalcPhaseAngleCurrent2()
            {
                _PhaseAngleCurrent = KACUtils.clampDegrees360((Target.orbit.trueAnomaly * Mathf.Rad2Deg) + Target.orbit.argumentOfPeriapsis +
                    Target.orbit.LAN - ((Origin.orbit.trueAnomaly * Mathf.Rad2Deg ) + Origin.orbit.argumentOfPeriapsis + Origin.orbit.LAN));
            }

        public double PhaseAngleTarget360 {get{return KACUtils.clampDegrees360(_PhaseAngleTarget); }}
            public double PhaseAngleCurrent360 {get{return KACUtils.clampDegrees360(_PhaseAngleCurrent); }}

            //private KSPDateTime _AlignmentTime = new KSPDateTime(0);
            public KSPTimeSpan AlignmentTime
            {
                get
                {
                    double angleChangepersec = (360 / Target.orbit.period) - (360 / Origin.orbit.period);
                    double angleToMakeUp =PhaseAngleCurrent360-PhaseAngleTarget360;
                    if (angleToMakeUp > 0 && angleChangepersec > 0)
                        angleToMakeUp -= 360;
                    if (angleToMakeUp < 0 && angleChangepersec < 0)
                        angleToMakeUp += 360;
                    double UTToTarget = Math.Floor(Math.Abs(angleToMakeUp / angleChangepersec));
                    KSPTimeSpan tmeReturn = new KSPTimeSpan(UTToTarget);
                    return tmeReturn;
                }
            }
        }

    public class KACXFerModelPoint
    {
        public Double UT;
        public Int32 Origin;
        public Int32 Target;
        public Double PhaseAngle;

        public KACXFerModelPoint(Double NewUT, Int32 NewOrigin, Int32 NewTarget, Double NewPhase)
        {
            UT = NewUT;
            PhaseAngle = NewPhase;
            Origin = NewOrigin;
            Target = NewTarget;
        } 
    }

    //public class EarthTime
    //{
    //    static DateTime EarthTimeRoot = new DateTime(2013, 1, 1);
    //    public static Double EarthTimeEncode(DateTime Input)
    //    {
    //        return (Input - EarthTimeRoot).TotalSeconds;
    //    }
    //    public static DateTime EarthTimeDecode(Double Input)
    //    {
    //        return EarthTimeRoot.AddSeconds(Input);
    //    }
    //}
}
