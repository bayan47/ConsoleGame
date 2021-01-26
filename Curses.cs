using System;
using System.Runtime.InteropServices;

namespace sample1
{
    public class Curses
    {
        const string ncurses = "libpdcursesw.dll"; // путь до библиотеки

        private IntPtr window; // создаем указатель

        [DllImport(ncurses, CallingConvention = CallingConvention.Cdecl)] // подключение C++ библиотеки для работы с терминалом
        private extern static IntPtr initscr(); // импортирование метода, переводящего терминал в curses-режим

        public Curses()
        {
            window = initscr();
        }

        [DllImport(ncurses, CallingConvention = CallingConvention.Cdecl)]
        private extern static int endwin(); // импортирование метода, приводящего терминал в нормальный режим
        ~Curses()       // деструктор класса
        {
            int result = endwin();
        }

        [DllImport(ncurses, CallingConvention = CallingConvention.Cdecl)]

        private extern static int cbreak();

        internal int CBreak()
        {
            return cbreak();
        }

        [DllImport(ncurses, CallingConvention = CallingConvention.Cdecl)]
        private extern static int halfdelay(int flt);

        internal int Halfdelay (int flt)
        {
            return halfdelay(flt);
        }
        [DllImport(ncurses, CallingConvention = CallingConvention.Cdecl)]

        private extern static int nodelay(IntPtr window,bool mode);
        
        internal int NoDelay(bool mode)
        {
            return nodelay(window,mode);
        } 
        [DllImport(ncurses, CallingConvention = CallingConvention.Cdecl)]
        private extern static int mvwprintw(IntPtr window, int y, int x, string message); //импортирование метода, позволяющего напечатать символ по указанным координатам
        public int Print(int x, int y, string message)
        {
            return mvwprintw(window, y, x, message);
        }
        
        internal int Print(Vector2 point, string message)
        {
            return mvwprintw(window, point.y, point.x, message);
        }

        internal int Print(Entity entity)
        {
            return mvwprintw(window, entity.world_position.y, entity.world_position.x, entity.content);
        }

        [DllImport(ncurses, CallingConvention = CallingConvention.Cdecl)]
        private extern static int refresh(IntPtr window);
        /// <summary>
        /// Обновить экран
        /// </summary>
        public int Refresh()
        {
            return refresh(window);
        }


         [DllImport(ncurses, CallingConvention = CallingConvention.Cdecl)]
        private extern static int move(int y, int x);
        /// <summary>
        /// Переместить курсор по координатам
        /// </summary>
        public int Move(int x, int y)
        {
            return move(y, x);
        }
        internal int Move(Vector2 point)
        {
            return move(point.y, point.x);
        }

        [DllImport(ncurses, CallingConvention = CallingConvention.Cdecl)]
        private extern static int wclear(IntPtr window);

        public int Clear()
        {
            return wclear(window);
        }

        [DllImport(ncurses, CallingConvention = CallingConvention.Cdecl)]
        private extern static int insertln();
        /// <summary>
        /// Вставить строку
        /// </summary>
        public int InsertLine()
        {
            return insertln();
        }
        [DllImport(ncurses, CallingConvention = CallingConvention.Cdecl)]
        private extern static int deleteln();
        /// <summary>
        /// Удалить строку
        /// </summary>
        public int DeleteLine()
        {
            return deleteln();
        }

        [DllImport(ncurses, CallingConvention = CallingConvention.Cdecl)]
        private extern static int wgetch(IntPtr window);

        public int GetKeyDown()
        {
            return wgetch(window);
        }

        [DllImport(ncurses, CallingConvention = CallingConvention.Cdecl)]
        private extern static void noecho();

        public void noEcho()
        {
             noecho();
        }

        [DllImport(ncurses, CallingConvention = CallingConvention.Cdecl)]
        private extern static void curs_set(int mode);

        public void SetCursorMode(int mode)
        {
            curs_set(mode);
        }
    }
}