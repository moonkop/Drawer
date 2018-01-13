﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drawer.Model;
using Drawer.Untils;
using Drawer.Forms;
namespace Drawer.Control
{
   public class DrawSession
    {
        List<Student> studentReady;
        Random random;

  

        public DrawSession(List<Student> studentReady)
        {
            this.studentReady = studentReady;
            if (studentReady.Count==0)
            {
                throw new Exception("当前方式已经抽完");
            }
            random = new Random();

        }
 
        public Student nextWinner()
        {
            if (studentReady == null)
            {
                throw new Exception("未指定学生列表");
            }
            Student winner=  studentReady.ElementAt(random.Next(studentReady.Count));
            return winner;
        }
        public Student GetFinalWinner()
        {
            Student student = nextWinner();
            studentReady.Remove(student);
            return student;

        }
        public int Count
        {
            get
            {
                return studentReady.Count;

            }
        }

    }
}