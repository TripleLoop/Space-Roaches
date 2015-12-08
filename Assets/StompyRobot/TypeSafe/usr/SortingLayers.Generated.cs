// ------------------------------------------------------------------------------
//  _______   _____ ___ ___   _   ___ ___ 
// |_   _\ \ / / _ \ __/ __| /_\ | __| __|
//   | |  \ V /|  _/ _|\__ \/ _ \| _|| _| 
//   |_|   |_| |_| |___|___/_/ \_\_| |___|
// 
// This file has been generated automatically by TypeSafe.
// Any changes to this file may be lost when it is regenerated.
// https://www.stompyrobot.uk/tools/typesafe
// 
// TypeSafe Version: 1.2.1-Unity5
// 
// ------------------------------------------------------------------------------



public sealed class SRSortingLayers {
    
    private SRSortingLayers() {
    }
    
    private const string _tsInternal = "1.2.1-Unity5";
    
    public static global::TypeSafe.SortingLayer Default {
        get {
            return __all[0];
        }
    }
    
    public static global::TypeSafe.SortingLayer Background {
        get {
            return __all[1];
        }
    }
    
    public static global::TypeSafe.SortingLayer Entities {
        get {
            return __all[2];
        }
    }
    
    public static global::TypeSafe.SortingLayer Foreground {
        get {
            return __all[3];
        }
    }
    
    public static global::TypeSafe.SortingLayer UI {
        get {
            return __all[4];
        }
    }
    
    private static global::System.Collections.Generic.IList<global::TypeSafe.SortingLayer> __all = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.SortingLayer>(new global::TypeSafe.SortingLayer[] {
                new global::TypeSafe.SortingLayer("Default", 0),
                new global::TypeSafe.SortingLayer("Background", -986088133),
                new global::TypeSafe.SortingLayer("Entities", 836349807),
                new global::TypeSafe.SortingLayer("Foreground", 111083535),
                new global::TypeSafe.SortingLayer("UI", 1908930663)});
    
    public static global::System.Collections.Generic.IList<global::TypeSafe.SortingLayer> All {
        get {
            return __all;
        }
    }
}
