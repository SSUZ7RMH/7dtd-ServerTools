﻿using System;
using System.Collections.Generic;
using System.Xml;

namespace ServerTools
{
    class BikeReturnConsole : ConsoleCmdAbstract
    {
        public override string GetDescription()
        {
            return "[ServerTools]- Enable or Disable Vehicle Teleport.";
        }
        public override string GetHelp()
        {
            return "Usage:\n" +
                   "  1. VehicleTeleport off\n" +
                   "  2. VehicleTeleport on\n" +
                   "  2. VehicleTeleport bike\n" +
                   "  2. VehicleTeleport minibike\n" +
                   "  2. VehicleTeleport motorbike\n" +
                   "  2. VehicleTeleport jeep\n" +
                   "  2. VehicleTeleport gyro\n" +
                   "1. Turn off the vehicle teleport\n" +
                   "2. Turn on the vehicle teleport\n" +
                   "2. Turn on/off the vehicle teleport for bike\n" +
                   "2. Turn on/off the vehicle teleport for minibike\n" +
                   "2. Turn on/off the vehicle teleport for motorbike\n" +
                   "2. Turn on/off the vehicle teleport for jeep\n" +
                   "2. Turn on/off the vehicle teleport for gyro\n";
        }
        public override string[] GetCommands()
        {
            return new string[] { "st-VehicleTeleport", "vehicleteleport", "vt" };
        }
        public override void Execute(List<string> _params, CommandSenderInfo _senderInfo)
        {
            try
            {
                if (_params.Count != 1)
                {
                    SdtdConsole.Instance.Output(string.Format("Wrong number of arguments, expected 1, found {0}", _params.Count));
                    return;
                }
                if (_params[0].ToLower().Equals("off"))
                {
                    VehicleTeleport.IsEnabled = false;
                    XmlDocument doc = new XmlDocument();
                    doc.Load("@" + API.ConfigPath + "/ServerToolsConfig.xml");
                    XmlNodeList aNodes = doc.SelectNodes("/ServerTools/Tools");
                    foreach (XmlNode aNode in aNodes)
                    {
                        XmlAttribute _attribute1 = aNode.Attributes["Name"];
                        XmlAttribute _attribute2 = aNode.Attributes["Enable"];
                        if (_attribute1 != null && _attribute1.Value == "Vehicle_Teleport" && _attribute2 != null)
                        {
                            _attribute2.Value = "False";
                        }
                    }
                    doc.Save("@" + API.ConfigPath + "/ServerToolsConfig.xml");
                    SdtdConsole.Instance.Output(string.Format("Vehicle teleport has been set to off"));
                    return;
                }
                else if (_params[0].ToLower().Equals("on"))
                {
                    VehicleTeleport.IsEnabled = true;
                    XmlDocument doc = new XmlDocument();
                    doc.Load("@" + API.ConfigPath + "/ServerToolsConfig.xml");
                    XmlNodeList aNodes = doc.SelectNodes("/ServerTools/Tools");
                    foreach (XmlNode aNode in aNodes)
                    {
                        XmlAttribute _attribute1 = aNode.Attributes["Name"];
                        XmlAttribute _attribute2 = aNode.Attributes["Enable"];
                        if (_attribute1 != null && _attribute1.Value == "Vehicle_Teleport" && _attribute2 != null)
                        {
                            _attribute2.Value = "True";
                        }
                    }
                    doc.Save("@" + API.ConfigPath + "/ServerToolsConfig.xml");
                    SdtdConsole.Instance.Output(string.Format("Vehicle teleport has been set to on"));
                    return;
                }
                else if (_params[0].ToLower().Equals("bike"))
                {
                    if (VehicleTeleport.Bike)
                    {
                        VehicleTeleport.IsEnabled = false;
                        SdtdConsole.Instance.Output(string.Format("Vehicle teleport: Bike has been set to off"));
                        return;
                    }
                    else
                    {
                        VehicleTeleport.IsEnabled = true;
                        SdtdConsole.Instance.Output(string.Format("Vehicle teleport: Bike has been set to on"));
                        return;
                    }
                    
                }
                else if (_params[0].ToLower().Equals("minibike"))
                {
                    if (VehicleTeleport.Mini_Bike)
                    {
                        VehicleTeleport.Mini_Bike = false;
                        SdtdConsole.Instance.Output(string.Format("Vehicle teleport: Minibike has been set to off"));
                        return;
                    }
                    else
                    {
                        VehicleTeleport.Mini_Bike = true;
                        SdtdConsole.Instance.Output(string.Format("Vehicle teleport: Minibike has been set to on"));
                        return;
                    }
                }
                else if (_params[0].ToLower().Equals("motorbike"))
                {
                    if (VehicleTeleport.Motor_Bike)
                    {
                        VehicleTeleport.Motor_Bike = false;
                        SdtdConsole.Instance.Output(string.Format("Vehicle teleport: Motorbike has been set to off"));
                        return;
                    }
                    else
                    {
                        VehicleTeleport.Motor_Bike = true;
                        SdtdConsole.Instance.Output(string.Format("Vehicle teleport: Motorbike has been set to on"));
                        return;
                    }
                }
                else if (_params[0].ToLower().Equals("jeep"))
                {
                    if (VehicleTeleport.Jeep)
                    {
                        VehicleTeleport.Jeep = false;
                        SdtdConsole.Instance.Output(string.Format("Vehicle teleport: Jeep has been set to off"));
                        return;
                    }
                    else
                    {
                        VehicleTeleport.Jeep = true;
                        SdtdConsole.Instance.Output(string.Format("Vehicle teleport: Jeep has been set to on"));
                        return;
                    }
                }
                else if (_params[0].ToLower().Equals("gyro"))
                {
                    if (VehicleTeleport.Gyro)
                    {
                        VehicleTeleport.Gyro = false;
                        SdtdConsole.Instance.Output(string.Format("Vehicle teleport: Gyro has been set to off"));
                        return;
                    }
                    else
                    {
                        VehicleTeleport.Gyro = true;
                        SdtdConsole.Instance.Output(string.Format("Vehicle teleport: Gyro has been set to on"));
                        return;
                    }
                }
                else
                {
                    SdtdConsole.Instance.Output(string.Format("Invalid argument {0}.", _params[0]));
                }
            }
            catch (Exception e)
            {
                Log.Out(string.Format("[SERVERTOOLS] Error in VehicleTeleportConsole.Run: {0}.", e));
            }
        }
    }
}