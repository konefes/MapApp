using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace MapApp
{
    public class RideSet
    {
        private int numRides;
        private string projectPath;
        private int currentRide;


        //surface, behavior, error variables
        private List<LocationCollection> surfaceTypePoints;
        private List<List<string>> surfaceType;
        private List<List<Pushpin>> surfacePins;
        
        private List<LocationCollection> behaviorTypePoints;
        private List<List<string>> behaviorType;
        private List<List<Pushpin>> behaviorPins;
        
        private List<LocationCollection> errorTypePoints;
        private List<List<string>> errorType;
        private List<List<Pushpin>> errorPins;

        public RideSet()
        {
            numRides = 0;
            projectPath = "";
            currentRide = 0;

            surfaceTypePoints = new List<LocationCollection>();
            surfaceType = new List<List<string>>();
            surfacePins = new List<List<Pushpin>>();
            behaviorTypePoints = new List<LocationCollection>();
            behaviorType = new List<List<string>>();
            behaviorPins = new List<List<Pushpin>>();
            errorTypePoints = new List<LocationCollection>();
            errorType = new List<List<string>>();
            errorPins = new List<List<Pushpin>>();
        }

        public int NumRides
        {
            get { return numRides; }
            set
            {
                numRides = value;
                for (int i = 0; i < numRides; i++)
                {
                    surfaceTypePoints.Add(new LocationCollection());
                    surfaceType.Add(new List<string>());
                    surfacePins.Add(new List<Pushpin>());
                    behaviorTypePoints.Add(new LocationCollection());
                    behaviorType.Add(new List<string>());
                    behaviorPins.Add(new List<Pushpin>());
                    errorTypePoints.Add(new LocationCollection());
                    errorType.Add(new List<string>());
                    errorPins.Add(new List<Pushpin>());
                }

            }
        }

        public string ProjectPath
        {
            get { return projectPath; }
            set { projectPath = value; }
        }

        public int CurrentRide
        {
            get { return currentRide; }
            set { currentRide = value; }
        }


        public LocationCollection SurfaceTypePoints
        {
            get { return surfaceTypePoints[currentRide]; }
            set { surfaceTypePoints[currentRide] = value; }
        }
        public List<string> SurfaceType
        {
            get { return surfaceType[currentRide]; }
            set { surfaceType[currentRide] = value; }
        }
        public List<Pushpin> SurfacePins
        {
            get { return surfacePins[currentRide]; }
            set { surfacePins[currentRide] = value; }
        }
        public LocationCollection BehaviorTypePoints
        {
            get { return behaviorTypePoints[currentRide]; }
            set { behaviorTypePoints[currentRide] = value; }
        }
        public List<string> BehaviorType
        {
            get { return behaviorType[currentRide]; }
            set { behaviorType[currentRide] = value; }
        }
        public List<Pushpin> BehaviorPins
        {
            get { return behaviorPins[currentRide]; }
            set { behaviorPins[currentRide] = value; }
        }
        public LocationCollection ErrorTypePoints
        {
            get { return errorTypePoints[currentRide]; }
            set { errorTypePoints[currentRide] = value; }
        }
        public List<string> ErrorType
        {
            get { return errorType[currentRide]; }
            set { errorType[currentRide] = value; }
        }
        public List<Pushpin> ErrorPins
        {
            get { return errorPins[currentRide]; }
            set { errorPins[currentRide] = value; }
        }

    }//end class RideSet

}//end namespace