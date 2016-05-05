using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace MapApp
{
    //
    //Class to allow serialization of RideSet class, since Location, Pushpin, and LocationCollection classes are not serializable
    //
    [Serializable]
    public class RideSetSaveable
    {
        private int numRides;
        private string projectPath;
        private int currentRide;


        //surface, behavior, error variables
        private List<int> surfacePoints = new List<int>();
        private List<List<List<double>>> surfaceTypePoints = new List<List<List<double>>>();
        private List<List<string>> surfaceType = new List<List<string>>();
        private List<List<List<double>>> surfacePinLocations = new List<List<List<double>>>();
        private List<List<string>> surfacePinColors = new List<List<string>>();
        private List<List<string>> surfacePinContent = new List<List<string>>();

        private List<int> behaviorPoints = new List<int>();
        private List<List<List<double>>> behaviorTypePoints = new List<List<List<double>>>();
        private List<List<string>> behaviorType = new List<List<string>>();
        private List<List<List<double>>> behaviorPinLocations = new List<List<List<double>>>();
        private List<List<string>> behaviorPinColors = new List<List<string>>();
        private List<List<string>> behaviorPinContent = new List<List<string>>();

        private List<int> errorPoints = new List<int>();
        private List<List<List<double>>> errorTypePoints = new List<List<List<double>>>();
        private List<List<string>> errorType = new List<List<string>>();
        private List<List<List<double>>> errorPinLocations = new List<List<List<double>>>();
        private List<List<string>> errorPinColors = new List<List<string>>();
        private List<List<string>> errorPinContent = new List<List<string>>();

        public RideSetSaveable(RideSet rs)
        {
            numRides = rs.NumRides;
            projectPath = rs.ProjectPath;
            currentRide = rs.CurrentRide;
            

            for (int i = 0; i < numRides; i++)
            {
                rs.CurrentRide = i;

                surfacePoints.Add(rs.SurfaceTypePoints.Count);
                behaviorPoints.Add(rs.BehaviorTypePoints.Count);
                errorPoints.Add(rs.ErrorTypePoints.Count);


                surfaceTypePoints.Add(new List<List<double>>());
                surfaceType.Add( new List<string>());
                surfacePinLocations.Add(new List<List<double>>());
                surfacePinColors.Add(new List<string>());
                surfacePinContent.Add(new List<string>());
                for (int j = 0; j < surfacePoints[i]; j++)
                {
                    surfaceTypePoints[i].Add(new List<double>());
                    surfacePinLocations[i].Add(new List<double>());
                    surfaceTypePoints[i][j].Add(rs.SurfaceTypePoints[j].Latitude);
                    surfaceTypePoints[i][j].Add(rs.SurfaceTypePoints[j].Longitude);
                    surfaceType[i].Add(rs.SurfaceType[j]);
                    surfacePinLocations[i][j].Add(rs.SurfacePins[j].Location.Latitude);
                    surfacePinLocations[i][j].Add(rs.SurfacePins[j].Location.Longitude);
                    surfacePinColors[i].Add(rs.SurfacePins[j].Background.ToString());
                    surfacePinContent[i].Add(rs.SurfacePins[j].Content.ToString());
                }

                behaviorTypePoints.Add(new List<List<double>>());
                behaviorType.Add(new List<string>());
                behaviorPinLocations.Add(new List<List<double>>());
                behaviorPinColors.Add(new List<string>());
                behaviorPinContent.Add(new List<string>());
                for (int j = 0; j < behaviorPoints[i]; j++)
                {
                    behaviorTypePoints[i].Add(new List<double>());
                    behaviorPinLocations[i].Add(new List<double>());
                    behaviorTypePoints[i][j].Add(rs.BehaviorTypePoints[j].Latitude);
                    behaviorTypePoints[i][j].Add(rs.BehaviorTypePoints[j].Longitude);
                    behaviorType[i].Add(rs.BehaviorType[j]);
                    behaviorPinLocations[i][j].Add(rs.BehaviorPins[j].Location.Latitude);
                    behaviorPinLocations[i][j].Add(rs.BehaviorPins[j].Location.Longitude);
                    behaviorPinColors[i].Add(rs.BehaviorPins[j].Background.ToString());
                    behaviorPinContent[i].Add(rs.BehaviorPins[j].Content.ToString());
                }

                errorTypePoints.Add(new List<List<double>>());
                errorType.Add(new List<string>());
                errorPinLocations.Add(new List<List<double>>());
                errorPinColors.Add(new List<string>());
                errorPinContent.Add(new List<string>());
                for (int j = 0; j < errorPoints[i]; j++)
                {
                    errorTypePoints[i].Add(new List<double>());
                    errorPinLocations[i].Add(new List<double>());
                    errorTypePoints[i][j].Add(rs.ErrorTypePoints[j].Latitude);
                    errorTypePoints[i][j].Add(rs.ErrorTypePoints[j].Longitude);
                    errorType[i].Add(rs.ErrorType[j]);
                    errorPinLocations[i][j].Add(rs.ErrorPins[j].Location.Latitude);
                    errorPinLocations[i][j].Add(rs.ErrorPins[j].Location.Longitude);
                    errorPinColors[i].Add(rs.ErrorPins[j].Background.ToString());
                    errorPinContent[i].Add(rs.ErrorPins[j].Content.ToString());
                }
            }

            rs.CurrentRide = currentRide;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //Convert back from serializable object to RideSet
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        public RideSet ConvertBack()
        {
            RideSet rs = new RideSet();

            rs.NumRides = numRides;
            rs.ProjectPath = projectPath;

            for (int i = 0; i < numRides; i++)
            {
                rs.CurrentRide = i;

                for (int j = 0; j < surfacePoints[i]; j++)
                {
                    rs.SurfaceTypePoints.Add(new Location(surfaceTypePoints[i][j][0], surfaceTypePoints[i][j][1]));
                   
                    rs.SurfaceType.Add(surfaceType[i][j]);
                    
                    Pushpin newPin = new Pushpin();
                    newPin.Location = new Location(surfacePinLocations[i][j][0], surfacePinLocations[i][j][1]);
                    newPin.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(surfacePinColors[i][j]));
                    newPin.Content = surfacePinContent[i][j];
                    rs.SurfacePins.Add(newPin);
                }
                
                for (int j = 0; j < behaviorPoints[i]; j++)
                {
                    rs.BehaviorTypePoints.Add(new Location(behaviorTypePoints[i][j][0], behaviorTypePoints[i][j][1]));

                    rs.BehaviorType.Add(behaviorType[i][j]);

                    Pushpin newPin = new Pushpin();
                    newPin.Location = new Location(behaviorPinLocations[i][j][0], behaviorPinLocations[i][j][1]);
                    newPin.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(behaviorPinColors[i][j]));
                    newPin.Content = behaviorPinContent[i][j];
                    rs.BehaviorPins.Add(newPin);
                }
                for (int j = 0; j < errorPoints[i]; j++)
                {
                    rs.ErrorTypePoints.Add(new Location(errorTypePoints[i][j][0], errorTypePoints[i][j][1]));

                    rs.ErrorType.Add(errorType[i][j]);

                    Pushpin newPin = new Pushpin();
                    newPin.Location = new Location(errorPinLocations[i][j][0], errorPinLocations[i][j][1]);
                    newPin.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(errorPinColors[i][j]));
                    newPin.Content = errorPinContent[i][j];
                    rs.ErrorPins.Add(newPin);
                }
            }

            rs.CurrentRide = currentRide;
            return rs;
        }
    }
}
