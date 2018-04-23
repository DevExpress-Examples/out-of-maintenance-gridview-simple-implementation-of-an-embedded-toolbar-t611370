using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using T611370_CS.Models;

namespace T611370_CS.Models {
    public class InMemoryModel {
        const int DataItemsCount = 100;

        public int ID { get; set; }
        public string Text { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }

        public static List<InMemoryModel> GetGridModel() {
            List<InMemoryModel> typedList = new List<InMemoryModel>();
            Random randomizer = new Random();
            for (int i = 0; i < DataItemsCount; i++) {
                InMemoryModel item = new InMemoryModel() { ID = i, Text = "Text" + i, Value1 = i * 2, Value2 = i * 5 };
                typedList.Add(item);
            }
            return typedList;
        }
    }
}
