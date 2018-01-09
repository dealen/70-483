﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadingAndMultitasking.Helpers;

namespace ThreadingAndMultitasking
{
    public class ThreadStaticAttributeTest : IRun
    {
        [ThreadStaticAttribute]
        private int _field;

        public void Run()
        {
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine($"Thread A: {_field}");
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine($"Thread B: {_field}");
                }
            }).Start();
        }
    }
}
