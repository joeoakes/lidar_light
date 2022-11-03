/*
 * LazerEyes Settings.cs
 * Singleton associated with settings
 * Course- IST440
 * Author- Cameron Grande
 * Date Developed- 10/18/22
 * Last Changed- 10/20/22
 * Rev: 2
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazer_Eyes
{
    public sealed class Settings
    {
        //fields and attributes 
        private static Settings         s_settings;
        private static readonly object  s_padlock = new();

        private bool    _alertSettingsDefault;
        private bool    _auditoryDanger;
        private bool    _auditoryDefault;
        private bool    _auditoryWarnings;
        private double  _distanceThreshold;
        private int     _distanceUnit;
        private bool    _lowLightToggle;
        private bool    _notificationSettingsDefault;
        private double  _strideLength;
        private bool    _tactileDanger;
        private double  _tactileDangerIntensity;
        private double  _tactileWarningIntensity;
        private bool    _tactileSettingsDefault;
        private bool    _tactileWarnings;
        private double  _volume;

        private const bool      AlertSettingsDefault =           true;
        private const bool      AuditoryDanger =                 true;
        private const bool      AuditoryDefault =                true;
        private const bool      AuditorySettingsDefault =        true;
        private const bool      AuditoryWarnings =               true;
        private const double    DistanceThresholdDefault =       5.0;
        private const int       DistanceUnitDefault =            (int) Units.Meters;
        private const bool      LowLightToggleDefault =          true;
        private const bool      NotificationSettingsDefault =    true;
        private const double    StrideLengthDefault =            5.0;
        private const bool      TactileDangerDefault =           true;
        private const double    TactileIntensityWarningDefault = 50.0;
        private const double    TactileIntensityDangerDefault =  50.0;
        private const bool      TactileWarningsDefault =         true;
        private const double    Volume =                         50.0;

        public enum Units
        {
            Meters,
            Feet,
            Steps
        }

        //Constructor- will check/load if settings already exist, if not will load defaults.
        private Settings()
        {
            if (!Preferences.ContainsKey("alertSettingsDefault"))
            {
                Preferences.Set("alertSettingsDefault", AlertSettingsDefault);
                Preferences.Set("distanceUnit", DistanceUnitDefault);
                Preferences.Set("distanceThreshold", DistanceThresholdDefault);
                Preferences.Set("strideLength", StrideLengthDefault);
                Preferences.Set("notificationSettingsDefault", NotificationSettingsDefault);
                Preferences.Set("auditoryDefault", AuditoryDefault);
                Preferences.Set("volume", Volume);
                Preferences.Set("auditoryWarnings", AuditoryWarnings);
                Preferences.Set("auditoryDanger", AuditoryDanger);
                Preferences.Set("tactileSettingsDefault", AuditorySettingsDefault);
                Preferences.Set("tactileWarnings", TactileWarningsDefault);
                Preferences.Set("tactileDanger", TactileDangerDefault);
                Preferences.Set("tactileWarningIntensity", TactileIntensityWarningDefault);
                Preferences.Set("tactileDangerIntensity", TactileIntensityDangerDefault);
                Preferences.Set("lowLightToggle", LowLightToggleDefault);
            }
            _alertSettingsDefault = Preferences.Get("alertSettingsDefault", AlertSettingsDefault);
            _distanceUnit = Preferences.Get("distanceUnit", DistanceUnitDefault);           
            _distanceThreshold = Preferences.Get("distanceThreshold", DistanceThresholdDefault);
            _strideLength = Preferences.Get("strideLength", StrideLengthDefault);
            _notificationSettingsDefault = Preferences.Get("notificationSettingsDefault", NotificationSettingsDefault);
            _auditoryDefault = Preferences.Get("auditoryDefault", AuditoryDefault);
            _volume = Preferences.Get("volume", Volume);
            _auditoryWarnings = Preferences.Get("auditoryWarnings", AuditoryWarnings);
            _auditoryDanger = Preferences.Get("auditoryDanger", AuditoryDanger);
            _tactileSettingsDefault = Preferences.Get("tactileSettingsDefault", AuditorySettingsDefault);
            _tactileWarnings = Preferences.Get("tactileWarnings", TactileWarningsDefault);
            _tactileDanger = Preferences.Get("tactileDanger", TactileDangerDefault);
            _tactileWarningIntensity = Preferences.Get("tactileWarningIntensity", TactileIntensityWarningDefault);
            _tactileDangerIntensity = Preferences.Get("tactileDangerIntensity", TactileIntensityDangerDefault);
            _lowLightToggle = Preferences.Get("lowLightToggle", LowLightToggleDefault);
        }

        //Get- singleton implementation that will get settings instance in thread-safe manor
        public static Settings Get()
        {
            lock (s_padlock)
            {
                if (s_settings == null)
                {
                    s_settings = new Settings();
                }
                return s_settings;
            }
        }

        //setters and getters below
        public bool GetAlertSettingsDefault()
        {
            return _alertSettingsDefault;
        }
        public void SetAlertSettingsDefault(bool alertSettingsDefault)
        {
            this._alertSettingsDefault = alertSettingsDefault;
            Preferences.Set("alertSettingsDefault", alertSettingsDefault);
        }
        public int GetDistanceUnit()
        {
            return _distanceUnit;
        }
        public void SetDistanceUnit(int distanceUnit)
        {
            this._distanceUnit = distanceUnit;
            Preferences.Set("distanceUnit", distanceUnit);
        }
        public double GetDistanceThreshold()
        {
            return _distanceThreshold;
        }
        public void SetDistanceThreshold(double distanceThreshold)
        {
            this._distanceThreshold = distanceThreshold;
            Preferences.Set("distanceThreshold", distanceThreshold);
        }
        public double GetStrideLength()
        {
            return _strideLength;
        }
        public void SetStrideLength(double strideLength)
        {
            this._strideLength = strideLength;
            Preferences.Set("strideLength", strideLength);
        }
        public bool GetNotificationSettingsDefault()
        {
            return _notificationSettingsDefault;
        }
        public void SetNotificationSettingsDefault(bool notificationSettingsDefault)
        {
            this._notificationSettingsDefault = notificationSettingsDefault;
            Preferences.Set("notificationSettingsDefault", notificationSettingsDefault);
        }
        public bool GetAuditoryDefault()
        {
            return _auditoryDefault;
        }
        public void SetAuditoryDefault(bool auditoryDefault)
        {
            this._auditoryDefault = auditoryDefault;
            Preferences.Set("auditoryDefault", auditoryDefault);
        }
        public double GetVolume()
        {
            return _volume;
        }
        public void SetVolume(double volume)
        {
            this._volume = volume;
            Preferences.Set("volume", volume);
        }
        public bool GetAuditoryWarnings()
        {
            return _auditoryWarnings;
        }
        public void SetAuditoryWarnings(bool auditoryWarnings)
        {
            this._auditoryWarnings = auditoryWarnings;
            Preferences.Set("auditoryWarnings", auditoryWarnings);
        }
        public bool GetAuditoryDanger()
        {
            return _auditoryDanger;
        }
        public void SetAuditoryDanger(bool auditoryDanger)
        {
            this._auditoryDanger = auditoryDanger;
            Preferences.Set("auditoryDanger", auditoryDanger);
        }
        public bool GetTactileSettingsDefault()
        {
            return _tactileSettingsDefault;
        }
        public void SetTactileSettingsDefault(bool tactileSettingsDefault)
        {
            this._tactileSettingsDefault = tactileSettingsDefault;
            Preferences.Set("tactileSettingsDefault", tactileSettingsDefault);
        }
        public bool GetTactileWarnings()
        {
            return _tactileWarnings;
        }
        public void SetTactileWarnings(bool tactileWarnings)
        {
            this._tactileWarnings = tactileWarnings;
            Preferences.Set("tactileWarnings", tactileWarnings);
        }
        public bool GetTactileDanger()
        {
            return _tactileDanger;
        }
        public void SetTactileDanger(bool tactileDanger)
        {
            this._tactileDanger = tactileDanger;
            Preferences.Set("tactileDanger", tactileDanger);
        }
        public double GetTactileWarningIntensity()
        {
            return _tactileWarningIntensity;
        }
        public void SetTactileDangerIntensity(double tactileDangerIntensity)
        {
            this._tactileDangerIntensity = tactileDangerIntensity;
            Preferences.Set("tactileDangerIntensity", tactileDangerIntensity);
        }
        public double GetTactileDangerIntensity()
        {
            return _tactileDangerIntensity;
        }
        public void SetTactileWarningIntensity(double tactileWarningIntensity)
        {
            this._tactileWarningIntensity = tactileWarningIntensity;
            Preferences.Set("tactileWarningIntensity", tactileWarningIntensity);
        }
        public bool GetLowLightToggle()
        {
            return _lowLightToggle;
        }
        public void SetLowLightToggle(bool lowLightToggle)
        {
            this._lowLightToggle = lowLightToggle;
            Preferences.Set("lowLightToggle", lowLightToggle);
        }
    }
}
