﻿using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        // Tạo một danh sách
        List<string> albums = new List<string>() { "Red", "Midnight", "Reputation" };

        // Duyệt qua danh sách albums  
        for (int i = 0; i < albums.Count; i++)
        {
            Console.WriteLine(albums[i]);
        }
    }
}
