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



public sealed class SRResources {
    
    private SRResources() {
    }
    
    private const string _tsInternal = "1.2.1-Unity5";
    
    private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[0]);
    
    public sealed class Core {
        
        private Core() {
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[0]);
        
        public sealed class Items {
            
            private Items() {
            }
            
            public static global::TypeSafe.PrefabResource PizzaSlize {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("PizzaSlize", "Core/Items/PizzaSlize")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        public sealed class Particles {
            
            private Particles() {
            }
            
            public static global::TypeSafe.PrefabResource Dash {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                }
            }
            
            public static global::TypeSafe.PrefabResource PizzaAura {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[1]));
                }
            }
            
            public static global::TypeSafe.PrefabResource RoachExplosion {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[2]));
                }
            }
            
            public static global::TypeSafe.PrefabResource SpikeExplosion {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[3]));
                }
            }
            
            public static global::TypeSafe.PrefabResource AstronautExplosion {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[4]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("Dash", "Core/Particles/Dash"),
                        new global::TypeSafe.PrefabResource("PizzaAura", "Core/Particles/PizzaAura"),
                        new global::TypeSafe.PrefabResource("RoachExplosion", "Core/Particles/RoachExplosion"),
                        new global::TypeSafe.PrefabResource("SpikeExplosion", "Core/Particles/SpikeExplosion"),
                        new global::TypeSafe.PrefabResource("AstronautExplosion", "Core/Particles/AstronautExplosion")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        public sealed class Audio {
            
            private Audio() {
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[0]);
            
            public sealed class Clips {
                
                private Clips() {
                }
                
                private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[0]);
                
                public sealed class SoundEffects {
                    
                    private SoundEffects() {
                    }
                    
                    public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> Confirm {
                        get {
                            return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(__ts_internal_resources[0]));
                        }
                    }
                    
                    public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> StrongHit {
                        get {
                            return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(__ts_internal_resources[1]));
                        }
                    }
                    
                    public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> MediumHit {
                        get {
                            return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(__ts_internal_resources[2]));
                        }
                    }
                    
                    public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> BasicCancel {
                        get {
                            return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(__ts_internal_resources[3]));
                        }
                    }
                    
                    public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> WeakHit {
                        get {
                            return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(__ts_internal_resources[4]));
                        }
                    }
                    
                    public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> Bee_Buzz_1 {
                        get {
                            return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(__ts_internal_resources[5]));
                        }
                    }
                    
                    public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> WallHit {
                        get {
                            return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(__ts_internal_resources[6]));
                        }
                    }
                    
                    private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                                new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("Confirm", "Core/Audio/Clips/SoundEffects/Confirm"),
                                new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("StrongHit", "Core/Audio/Clips/SoundEffects/StrongHit"),
                                new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("MediumHit", "Core/Audio/Clips/SoundEffects/MediumHit"),
                                new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("BasicCancel", "Core/Audio/Clips/SoundEffects/BasicCancel"),
                                new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("WeakHit", "Core/Audio/Clips/SoundEffects/WeakHit"),
                                new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("Bee Buzz_1", "Core/Audio/Clips/SoundEffects/Bee Buzz_1"),
                                new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("WallHit", "Core/Audio/Clips/SoundEffects/WallHit")});
                    
                    /// <summary>
                    /// Return a list of all resources in this folder.
                    /// This method has a very low performance cost, no need to cache the result.
                    /// </summary>
                    /// <returns>A list of resource objects in this folder.</returns>
                    public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                        return __ts_internal_resources;
                    }
                    
                    private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
                    
                    /// <summary>
                    /// Return a list of all resources in this folder and all sub-folders.
                    /// The result of this method is cached, so subsequent calls will have very low performance cost.
                    /// </summary>
                    /// <returns>A list of resource objects in this folder and sub-folders.</returns>
                    public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                        if ((__ts_internal_recursiveLookupCache != null)) {
                            return __ts_internal_recursiveLookupCache;
                        }
                        global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                        tmp.AddRange(GetContents());
                        __ts_internal_recursiveLookupCache = tmp;
                        return __ts_internal_recursiveLookupCache;
                    }
                    
                    /// <summary>
                    /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
                    /// This method does not cache the result, so you should cache the result yourself if you will use it often.
                    /// </summary>
                    /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
                    public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                        where TResource : global::UnityEngine.Object {
                        return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
                    }
                    
                    /// <summary>
                    /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
                    /// This method does not cache the result, so you should cache the result yourself if you will use it often.
                    /// </summary>
                    /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
                    public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                        where TResource : global::UnityEngine.Object {
                        return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
                    }
                    
                    /// <summary>
                    /// Call Unload() on every loaded resource in this folder.
                    /// </summary>
                    public static void UnloadAll() {
                        global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
                    }
                    
                    /// <summary>
                    /// Call Unload() on every loaded resource in this folder and subfolders.
                    /// </summary>
                    private void UnloadAllRecursive() {
                        global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
                    }
                }
                
                public sealed class Music {
                    
                    private Music() {
                    }
                    
                    public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> RoachMenu {
                        get {
                            return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(__ts_internal_resources[0]));
                        }
                    }
                    
                    public static global::TypeSafe.Resource<global::UnityEngine.AudioClip> MainGame {
                        get {
                            return ((global::TypeSafe.Resource<global::UnityEngine.AudioClip>)(__ts_internal_resources[1]));
                        }
                    }
                    
                    private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                                new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("RoachMenu", "Core/Audio/Clips/Music/RoachMenu"),
                                new global::TypeSafe.Resource<global::UnityEngine.AudioClip>("MainGame", "Core/Audio/Clips/Music/MainGame")});
                    
                    /// <summary>
                    /// Return a list of all resources in this folder.
                    /// This method has a very low performance cost, no need to cache the result.
                    /// </summary>
                    /// <returns>A list of resource objects in this folder.</returns>
                    public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                        return __ts_internal_resources;
                    }
                    
                    private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
                    
                    /// <summary>
                    /// Return a list of all resources in this folder and all sub-folders.
                    /// The result of this method is cached, so subsequent calls will have very low performance cost.
                    /// </summary>
                    /// <returns>A list of resource objects in this folder and sub-folders.</returns>
                    public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                        if ((__ts_internal_recursiveLookupCache != null)) {
                            return __ts_internal_recursiveLookupCache;
                        }
                        global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                        tmp.AddRange(GetContents());
                        __ts_internal_recursiveLookupCache = tmp;
                        return __ts_internal_recursiveLookupCache;
                    }
                    
                    /// <summary>
                    /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
                    /// This method does not cache the result, so you should cache the result yourself if you will use it often.
                    /// </summary>
                    /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
                    public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                        where TResource : global::UnityEngine.Object {
                        return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
                    }
                    
                    /// <summary>
                    /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
                    /// This method does not cache the result, so you should cache the result yourself if you will use it often.
                    /// </summary>
                    /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
                    public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                        where TResource : global::UnityEngine.Object {
                        return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
                    }
                    
                    /// <summary>
                    /// Call Unload() on every loaded resource in this folder.
                    /// </summary>
                    public static void UnloadAll() {
                        global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
                    }
                    
                    /// <summary>
                    /// Call Unload() on every loaded resource in this folder and subfolders.
                    /// </summary>
                    private void UnloadAllRecursive() {
                        global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
                    }
                }
                
                /// <summary>
                /// Return a list of all resources in this folder.
                /// This method has a very low performance cost, no need to cache the result.
                /// </summary>
                /// <returns>A list of resource objects in this folder.</returns>
                public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                    return __ts_internal_resources;
                }
                
                private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
                
                /// <summary>
                /// Return a list of all resources in this folder and all sub-folders.
                /// The result of this method is cached, so subsequent calls will have very low performance cost.
                /// </summary>
                /// <returns>A list of resource objects in this folder and sub-folders.</returns>
                public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                    if ((__ts_internal_recursiveLookupCache != null)) {
                        return __ts_internal_recursiveLookupCache;
                    }
                    global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                    tmp.AddRange(GetContents());
                    tmp.AddRange(SoundEffects.GetContentsRecursive());
                    tmp.AddRange(Music.GetContentsRecursive());
                    __ts_internal_recursiveLookupCache = tmp;
                    return __ts_internal_recursiveLookupCache;
                }
                
                /// <summary>
                /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
                /// This method does not cache the result, so you should cache the result yourself if you will use it often.
                /// </summary>
                /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
                public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                    where TResource : global::UnityEngine.Object {
                    return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
                }
                
                /// <summary>
                /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
                /// This method does not cache the result, so you should cache the result yourself if you will use it often.
                /// </summary>
                /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
                public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                    where TResource : global::UnityEngine.Object {
                    return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
                }
                
                /// <summary>
                /// Call Unload() on every loaded resource in this folder.
                /// </summary>
                public static void UnloadAll() {
                    global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
                }
                
                /// <summary>
                /// Call Unload() on every loaded resource in this folder and subfolders.
                /// </summary>
                private void UnloadAllRecursive() {
                    global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
                }
            }
            
            public sealed class _Prefabs {
                
                private _Prefabs() {
                }
                
                public static global::TypeSafe.PrefabResource Music {
                    get {
                        return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                    }
                }
                
                public static global::TypeSafe.PrefabResource SoundEffects {
                    get {
                        return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[1]));
                    }
                }
                
                private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                            new global::TypeSafe.PrefabResource("Music", "Core/Audio/_Prefabs/Music"),
                            new global::TypeSafe.PrefabResource("SoundEffects", "Core/Audio/_Prefabs/SoundEffects")});
                
                /// <summary>
                /// Return a list of all resources in this folder.
                /// This method has a very low performance cost, no need to cache the result.
                /// </summary>
                /// <returns>A list of resource objects in this folder.</returns>
                public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                    return __ts_internal_resources;
                }
                
                private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
                
                /// <summary>
                /// Return a list of all resources in this folder and all sub-folders.
                /// The result of this method is cached, so subsequent calls will have very low performance cost.
                /// </summary>
                /// <returns>A list of resource objects in this folder and sub-folders.</returns>
                public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                    if ((__ts_internal_recursiveLookupCache != null)) {
                        return __ts_internal_recursiveLookupCache;
                    }
                    global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                    tmp.AddRange(GetContents());
                    __ts_internal_recursiveLookupCache = tmp;
                    return __ts_internal_recursiveLookupCache;
                }
                
                /// <summary>
                /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
                /// This method does not cache the result, so you should cache the result yourself if you will use it often.
                /// </summary>
                /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
                public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                    where TResource : global::UnityEngine.Object {
                    return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
                }
                
                /// <summary>
                /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
                /// This method does not cache the result, so you should cache the result yourself if you will use it often.
                /// </summary>
                /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
                public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                    where TResource : global::UnityEngine.Object {
                    return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
                }
                
                /// <summary>
                /// Call Unload() on every loaded resource in this folder.
                /// </summary>
                public static void UnloadAll() {
                    global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
                }
                
                /// <summary>
                /// Call Unload() on every loaded resource in this folder and subfolders.
                /// </summary>
                private void UnloadAllRecursive() {
                    global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
                }
            }
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                tmp.AddRange(Clips.GetContentsRecursive());
                tmp.AddRange(_Prefabs.GetContentsRecursive());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        public sealed class Pools {
            
            private Pools() {
            }
            
            public static global::TypeSafe.PrefabResource Pizza_Pool {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Particle_Pool {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[1]));
                }
            }
            
            public static global::TypeSafe.PrefabResource SpikeBall_Pool {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[2]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Roach_Pool {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[3]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("Pizza_Pool", "Core/Pools/Pizza_Pool"),
                        new global::TypeSafe.PrefabResource("Particle_Pool", "Core/Pools/Particle_Pool"),
                        new global::TypeSafe.PrefabResource("SpikeBall_Pool", "Core/Pools/SpikeBall_Pool"),
                        new global::TypeSafe.PrefabResource("Roach_Pool", "Core/Pools/Roach_Pool")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        public sealed class Base {
            
            private Base() {
            }
            
            public static global::TypeSafe.PrefabResource BaseCamera {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                }
            }
            
            public static global::TypeSafe.PrefabResource SoundManager {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[1]));
                }
            }
            
            public static global::TypeSafe.PrefabResource WaveManager {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[2]));
                }
            }
            
            public static global::TypeSafe.PrefabResource UserInput {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[3]));
                }
            }
            
            public static global::TypeSafe.PrefabResource PlayerPrefsManager {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[4]));
                }
            }
            
            public static global::TypeSafe.PrefabResource EntitySpawner {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[5]));
                }
            }
            
            public static global::TypeSafe.PrefabResource ChargeDash {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[6]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Game {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[7]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("BaseCamera", "Core/Base/BaseCamera"),
                        new global::TypeSafe.PrefabResource("SoundManager", "Core/Base/SoundManager"),
                        new global::TypeSafe.PrefabResource("WaveManager", "Core/Base/WaveManager"),
                        new global::TypeSafe.PrefabResource("UserInput", "Core/Base/UserInput"),
                        new global::TypeSafe.PrefabResource("PlayerPrefsManager", "Core/Base/PlayerPrefsManager"),
                        new global::TypeSafe.PrefabResource("EntitySpawner", "Core/Base/EntitySpawner"),
                        new global::TypeSafe.PrefabResource("ChargeDash", "Core/Base/ChargeDash"),
                        new global::TypeSafe.PrefabResource("Game", "Core/Base/Game")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        public sealed class UI {
            
            private UI() {
            }
            
            public static global::TypeSafe.PrefabResource EventSystem {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Canvas {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[1]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("EventSystem", "Core/UI/EventSystem"),
                        new global::TypeSafe.PrefabResource("Canvas", "Core/UI/Canvas")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        public sealed class Environment {
            
            private Environment() {
            }
            
            public static global::TypeSafe.PrefabResource background {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                }
            }
            
            public static global::TypeSafe.PrefabResource gameWalls {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[1]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("background", "Core/Environment/background"),
                        new global::TypeSafe.PrefabResource("gameWalls", "Core/Environment/gameWalls")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        public sealed class Characters {
            
            private Characters() {
            }
            
            public static global::TypeSafe.PrefabResource Spikeball {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Roach {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[1]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Astronaut {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[2]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("Spikeball", "Core/Characters/Spikeball"),
                        new global::TypeSafe.PrefabResource("Roach", "Core/Characters/Roach"),
                        new global::TypeSafe.PrefabResource("Astronaut", "Core/Characters/Astronaut")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        /// <summary>
        /// Return a list of all resources in this folder.
        /// This method has a very low performance cost, no need to cache the result.
        /// </summary>
        /// <returns>A list of resource objects in this folder.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
            return __ts_internal_resources;
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
        
        /// <summary>
        /// Return a list of all resources in this folder and all sub-folders.
        /// The result of this method is cached, so subsequent calls will have very low performance cost.
        /// </summary>
        /// <returns>A list of resource objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
            if ((__ts_internal_recursiveLookupCache != null)) {
                return __ts_internal_recursiveLookupCache;
            }
            global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
            tmp.AddRange(GetContents());
            tmp.AddRange(Items.GetContentsRecursive());
            tmp.AddRange(Particles.GetContentsRecursive());
            tmp.AddRange(Audio.GetContentsRecursive());
            tmp.AddRange(Pools.GetContentsRecursive());
            tmp.AddRange(Base.GetContentsRecursive());
            tmp.AddRange(UI.GetContentsRecursive());
            tmp.AddRange(Environment.GetContentsRecursive());
            tmp.AddRange(Characters.GetContentsRecursive());
            __ts_internal_recursiveLookupCache = tmp;
            return __ts_internal_recursiveLookupCache;
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder.
        /// </summary>
        public static void UnloadAll() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder and subfolders.
        /// </summary>
        private void UnloadAllRecursive() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
        }
    }
    
    public sealed class Menu {
        
        private Menu() {
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[0]);
        
        public sealed class UI {
            
            private UI() {
            }
            
            public static global::TypeSafe.PrefabResource EventSystem {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                }
            }
            
            public static global::TypeSafe.PrefabResource Canvas {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[1]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("EventSystem", "Menu/UI/EventSystem"),
                        new global::TypeSafe.PrefabResource("Canvas", "Menu/UI/Canvas")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        public sealed class Environment {
            
            private Environment() {
            }
            
            public static global::TypeSafe.PrefabResource MainScreenBG {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("MainScreenBG", "Menu/Environment/MainScreenBG")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        public sealed class Base {
            
            private Base() {
            }
            
            public static global::TypeSafe.PrefabResource MainMenu {
                get {
                    return ((global::TypeSafe.PrefabResource)(__ts_internal_resources[0]));
                }
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_resources = new global::System.Collections.ObjectModel.ReadOnlyCollection<global::TypeSafe.IResource>(new global::TypeSafe.IResource[] {
                        new global::TypeSafe.PrefabResource("MainMenu", "Menu/Base/MainMenu")});
            
            /// <summary>
            /// Return a list of all resources in this folder.
            /// This method has a very low performance cost, no need to cache the result.
            /// </summary>
            /// <returns>A list of resource objects in this folder.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
                return __ts_internal_resources;
            }
            
            private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
            
            /// <summary>
            /// Return a list of all resources in this folder and all sub-folders.
            /// The result of this method is cached, so subsequent calls will have very low performance cost.
            /// </summary>
            /// <returns>A list of resource objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
                if ((__ts_internal_recursiveLookupCache != null)) {
                    return __ts_internal_recursiveLookupCache;
                }
                global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
                tmp.AddRange(GetContents());
                __ts_internal_recursiveLookupCache = tmp;
                return __ts_internal_recursiveLookupCache;
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
            }
            
            /// <summary>
            /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
            /// This method does not cache the result, so you should cache the result yourself if you will use it often.
            /// </summary>
            /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
            public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
                where TResource : global::UnityEngine.Object {
                return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder.
            /// </summary>
            public static void UnloadAll() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
            }
            
            /// <summary>
            /// Call Unload() on every loaded resource in this folder and subfolders.
            /// </summary>
            private void UnloadAllRecursive() {
                global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
            }
        }
        
        /// <summary>
        /// Return a list of all resources in this folder.
        /// This method has a very low performance cost, no need to cache the result.
        /// </summary>
        /// <returns>A list of resource objects in this folder.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
            return __ts_internal_resources;
        }
        
        private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
        
        /// <summary>
        /// Return a list of all resources in this folder and all sub-folders.
        /// The result of this method is cached, so subsequent calls will have very low performance cost.
        /// </summary>
        /// <returns>A list of resource objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
            if ((__ts_internal_recursiveLookupCache != null)) {
                return __ts_internal_recursiveLookupCache;
            }
            global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
            tmp.AddRange(GetContents());
            tmp.AddRange(UI.GetContentsRecursive());
            tmp.AddRange(Environment.GetContentsRecursive());
            tmp.AddRange(Base.GetContentsRecursive());
            __ts_internal_recursiveLookupCache = tmp;
            return __ts_internal_recursiveLookupCache;
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
        }
        
        /// <summary>
        /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
        /// This method does not cache the result, so you should cache the result yourself if you will use it often.
        /// </summary>
        /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
        public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
            where TResource : global::UnityEngine.Object {
            return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder.
        /// </summary>
        public static void UnloadAll() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
        }
        
        /// <summary>
        /// Call Unload() on every loaded resource in this folder and subfolders.
        /// </summary>
        private void UnloadAllRecursive() {
            global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
        }
    }
    
    /// <summary>
    /// Return a list of all resources in this folder.
    /// This method has a very low performance cost, no need to cache the result.
    /// </summary>
    /// <returns>A list of resource objects in this folder.</returns>
    public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContents() {
        return __ts_internal_resources;
    }
    
    private static global::System.Collections.Generic.IList<global::TypeSafe.IResource> __ts_internal_recursiveLookupCache;
    
    /// <summary>
    /// Return a list of all resources in this folder and all sub-folders.
    /// The result of this method is cached, so subsequent calls will have very low performance cost.
    /// </summary>
    /// <returns>A list of resource objects in this folder and sub-folders.</returns>
    public static global::System.Collections.Generic.IList<global::TypeSafe.IResource> GetContentsRecursive() {
        if ((__ts_internal_recursiveLookupCache != null)) {
            return __ts_internal_recursiveLookupCache;
        }
        global::System.Collections.Generic.List<global::TypeSafe.IResource> tmp = new global::System.Collections.Generic.List<global::TypeSafe.IResource>();
        tmp.AddRange(GetContents());
        tmp.AddRange(Core.GetContentsRecursive());
        tmp.AddRange(Menu.GetContentsRecursive());
        __ts_internal_recursiveLookupCache = tmp;
        return __ts_internal_recursiveLookupCache;
    }
    
    /// <summary>
    /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref> (does not include sub-folders)
    /// This method does not cache the result, so you should cache the result yourself if you will use it often.
    /// </summary>
    /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder.</returns>
    public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContents<TResource>()
        where TResource : global::UnityEngine.Object {
        return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContents());
    }
    
    /// <summary>
    /// Return a list of all resources in this folder of type <typeparamref>TResource</typeparamref>, including sub-folders.
    /// This method does not cache the result, so you should cache the result yourself if you will use it often.
    /// </summary>
    /// <returns>A list of <typeparamref>TResource</typeparamref> objects in this folder and sub-folders.</returns>
    public static global::System.Collections.Generic.List<global::TypeSafe.Resource<TResource>> GetContentsRecursive<TResource>()
        where TResource : global::UnityEngine.Object {
        return global::TypeSafe.TypeSafeUtil.GetResourcesOfType<TResource>(GetContentsRecursive());
    }
    
    /// <summary>
    /// Call Unload() on every loaded resource in this folder.
    /// </summary>
    public static void UnloadAll() {
        global::TypeSafe.TypeSafeUtil.UnloadAll(GetContents());
    }
    
    /// <summary>
    /// Call Unload() on every loaded resource in this folder and subfolders.
    /// </summary>
    private void UnloadAllRecursive() {
        global::TypeSafe.TypeSafeUtil.UnloadAll(GetContentsRecursive());
    }
}