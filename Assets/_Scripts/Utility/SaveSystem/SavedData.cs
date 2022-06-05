using System;

namespace SaveSystem
{
    [Serializable]
    public class SavedData
    {
        // Кэширую индекс текущего уровня
        
        public int CurrentLevel { get; set; }

        public SavedData()
        {
            //CurrentLevel = AdditiveManager.CurrentLevel;
        }
    }
}
