﻿using RimWorld;
using RimWorld.Planet;
using System;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace Colonystats.Utilities
{
    class ThingSelection
    {
        public static List<Thing> GetAllStoredThings()
        {            
            return Find.Maps.SelectMany(map => map.spawnedThings)
                .Where(thing => thing.Spawned &&
                                thing.IsInValidStorage())
                .OrderBy(thing => thing.thingIDNumber)
                .ToList();
        }

        public static List<Thing> GetAllStoredThingsThatContain(string name)
        {
            return Find.Maps.SelectMany(map => map.spawnedThings)
                .Where(thing => thing.Spawned &&
                                thing.IsInValidStorage() &&
                                thing.LabelNoCount.ToLower().Contains(name))
                .OrderBy(thing => thing.thingIDNumber)
                .ToList();
        }

        public static List<Thing> GetAllStoredThingsThatExactMatch(string name)
        {
            return Find.Maps.SelectMany(map => map.spawnedThings)
                .Where(thing => thing.Spawned &&
                                thing.IsInValidStorage() &&
                                thing.LabelNoCount.ToLower().Equals(name))
                .OrderBy(thing => thing.thingIDNumber)
                .ToList();
        }

        public static List<Thing> GetAllStoredNonMedicalDrugs()
        {
            return Find.Maps.SelectMany(map => map.spawnedThings)
                .Where(thing => thing.Spawned &&
                                thing.IsInValidStorage() &&
                                thing.def.IsNonMedicalDrug)
                .OrderBy(thing => thing.thingIDNumber)
                .ToList();
        }
    }
}
