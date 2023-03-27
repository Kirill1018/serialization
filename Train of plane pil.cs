using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using static System.Console;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Diagnostics.Tracing;
using System.Xml.Linq;
using System.IO;

namespace cs
{
    public delegate void rate_change(int rate);
    public delegate void height_change(int height);
    public delegate void form_key_down(int sender, KeyEventArgs event_args, BinaryWriter writer, int spacing, int distance, Dispatcher supervisor, Dispatcher manager, Random rand_val, string name, string behalf);
    public class Plane
    {
        public Plane()
        {

        }
        public int pitch, time, rate = 0, height = 0;//скорость и высота
        public void rapidity(int rate)
        {
            WriteLine($"скорость={rate}");
        }
        public void elevation(int height)
        {
            WriteLine($"высота={height}");
        }
        public event form_key_down key_down;
        public void right(int sender, KeyEventArgs event_args, BinaryWriter writer, int spacing, int distance, Dispatcher supervisor, Dispatcher manager, Random rand_val, string name, string behalf)
        {
            if (key_down != null) key_down(sender, event_args, writer, spacing, distance, supervisor, manager, rand_val, name, behalf);
        }
        public void form_load()
        {
            this.key_down += key_down;
        }
        public void form_key_down(object sender, KeyEventArgs event_args, BinaryWriter writer, int spacing, int distance, Dispatcher supervisor, Dispatcher manager, Random rand_val, int pace, string name, string behalf)
        {
            while (spacing < (distance / 2))
            {
                WriteLine("клавиша");
                ReadKey();
                WriteLine($"пройденное расстояние={spacing}");
                if (spacing == 0) supervisor.n = rand_val.Next(-200, 201);
                WriteLine($"корректировка погодных условий={supervisor.n}");
                writer.Write($"пройденное расстояние={spacing}");
                writer.Write($"корректировка погодных условий={supervisor.n}");
                if (event_args.KeyCode == Keys.Right)
                {
                    Button key = new Button();
                    key.PerformClick();
                    rate += 50;
                    supervisor.shift += rapidity;
                    if (rate > pace)
                    {
                        supervisor.pen_points += 100;
                        WriteLine($"количество штрафных очков={supervisor.pen_points}");
                        supervisor.decline();
                        WriteLine("снижение");
                        writer.Write($"количество штрафных очков={supervisor.pen_points}");
                        writer.Write($"снижение");
                    }
                }
                else if (event_args.KeyCode == Keys.Left)
                {
                    Button key = new Button();
                    key.PerformClick();
                    rate -= 50;
                    supervisor.shift += rapidity;
                    if (rate > pace)
                    {
                        supervisor.pen_points += 100;
                        WriteLine($"количество штрафных очков={supervisor.pen_points}");
                        supervisor.decline();
                        WriteLine("снижение");
                        writer.Write($"количество штрафных очков={supervisor.pen_points}");
                        writer.Write($"снижение");
                    }
                }
                else if (event_args.KeyCode == Keys.RShiftKey && event_args.KeyCode == Keys.Right)
                {
                    Button key = new Button();
                    key.PerformClick();
                    rate += 150;
                    supervisor.shift += rapidity;
                    if (rate > pace)
                    {
                        supervisor.pen_points += 100;
                        WriteLine($"количество штрафных очков={supervisor.pen_points}");
                        supervisor.decline();
                        WriteLine("снижение");
                        writer.Write($"количество штрафных очков={supervisor.pen_points}");
                        writer.Write($"снижение");
                    }
                }
                else if (event_args.KeyCode == Keys.RShiftKey && event_args.KeyCode == Keys.Left)
                {
                    Button key = new Button();
                    key.PerformClick();
                    rate -= 150;
                    supervisor.shift += rapidity;
                    if (rate > pace)
                    {
                        supervisor.pen_points += 100;
                        WriteLine($"количество штрафных очков={supervisor.pen_points}");
                        supervisor.decline();
                        WriteLine("снижение");
                        writer.Write($"количество штрафных очков={supervisor.pen_points}");
                        writer.Write($"снижение");
                    }
                }
                else if (event_args.KeyCode == Keys.Up)
                {
                    Button key = new Button();
                    key.PerformClick();
                    height += 250;
                    supervisor.altitude += elevation;
                    pitch = 7 * rate + supervisor.n;
                    if (pitch > 0)
                    {
                        WriteLine($"рекомендуемая высота={pitch}");
                        writer.Write($"рекомендуемая высота={pitch}");
                    }
                    if ((pitch - height) >= 300 || (pitch - height) < 600)
                    {
                        supervisor.pen_points += 25;
                        WriteLine($"количество штрафных очков={supervisor.pen_points}");
                        writer.Write($"количество штрафных очков={supervisor.pen_points}");
                    }
                    else if ((pitch - height) >= 600 || (pitch - height) < 1000)
                    {
                        supervisor.pen_points += 50;
                        WriteLine($"количество штрафных очков={supervisor.pen_points}");
                        writer.Write($"количество штрафных очков={supervisor.pen_points}");
                    }
                    else if ((pitch - height) > 1000)
                    {
                        Clear();
                        supervisor.crash();
                        WriteLine("крушение");
                        writer.Write("крушение");
                    }
                    if (height < pitch)
                    {
                        WriteLine("нужно поднять самолёт до рекомендуемой высоты");
                        writer.Write("нужно поднять самолёт до рекомендуемой высоты");
                    }
                    else if (height > pitch)
                    {
                        WriteLine("нужно спуститься до рекомендуемой высоты");
                        writer.Write("нужно спуститься до рекомендуемой высоты");
                    }
                }
                else if (event_args.KeyCode == Keys.Down)
                {
                    Button key = new Button();
                    key.PerformClick();
                    height -= 250;
                    supervisor.altitude += elevation;
                    pitch = 7 * rate + supervisor.n;
                    if (pitch > 0)
                    {
                        WriteLine($"рекомендуемая высота={pitch}");
                        writer.Write($"рекомендуемая высота={pitch}");
                    }
                    if ((pitch - height) >= 300 || (pitch - height) < 600)
                    {
                        supervisor.pen_points += 25;
                        WriteLine($"количество штрафных очков={supervisor.pen_points}");
                        writer.Write($"количество штрафных очков={supervisor.pen_points}");
                    }
                    else if ((pitch - height) >= 600 || (pitch - height) < 1000)
                    {
                        supervisor.pen_points += 50;
                        WriteLine($"количество штрафных очков={supervisor.pen_points}");
                        writer.Write($"количество штрафных очков={supervisor.pen_points}");
                    }
                    else if ((pitch - height) > 1000)
                    {
                        Clear();
                        supervisor.crash();
                        WriteLine("крушение");
                        writer.Write("крушение");
                    }
                    if (height < pitch)
                    {
                        WriteLine("нужно поднять самолёт до рекомендуемой высоты");
                        writer.Write("нужно поднять самолёт до рекомендуемой высоты");
                    }
                    else if (height > pitch)
                    {
                        WriteLine("нужно спуститься до рекомендуемой высоты");
                        writer.Write("нужно спуститься до рекомендуемой высоты");
                    }
                }
                else if (event_args.KeyCode == Keys.RShiftKey && event_args.KeyCode == Keys.Up)
                {
                    Button key = new Button();
                    key.PerformClick();
                    height += 500;
                    supervisor.altitude += elevation;
                    pitch = 7 * rate + supervisor.n;
                    if (pitch > 0)
                    {
                        WriteLine($"рекомендуемая высота={pitch}");
                        writer.Write($"рекомендуемая высота={pitch}");
                    }
                    if ((pitch - height) >= 300 || (pitch - height) < 600)
                    {
                        supervisor.pen_points += 25;
                        WriteLine($"количество штрафных очков={supervisor.pen_points}");
                        writer.Write($"количество штрафных очков={supervisor.pen_points}");
                    }
                    else if ((pitch - height) >= 600 || (pitch - height) < 1000)
                    {
                        supervisor.pen_points += 50;
                        WriteLine($"количество штрафных очков={supervisor.pen_points}");
                        writer.Write($"количество штрафных очков={supervisor.pen_points}");
                    }
                    else if ((pitch - height) > 1000)
                    {
                        Clear();
                        supervisor.crash();
                        WriteLine("крушение");
                        writer.Write("крушение");
                    }
                    if (height < pitch)
                    {
                        WriteLine("нужно поднять самолёт до рекомендуемой высоты");
                        writer.Write("нужно поднять самолёт до рекомендуемой высоты");
                    }
                    else if (height > pitch)
                    {
                        WriteLine("нужно спуститься до рекомендуемой высоты");
                        writer.Write("нужно спуститься до рекомендуемой высоты");
                    }
                }
                if (spacing == 0)
                {
                    WriteLine($"первый диспетчер {name}");
                    writer.Write($"первый диспетчер {name}");
                }
                if (rate > 50)
                {
                    WriteLine(supervisor.takeoff);
                    writer.Write(supervisor.takeoff);
                }
                if (rate < pace)
                {
                    WriteLine($"для набора высоты нужно достигнуть скорости={pace}");
                    writer.Write($"для набора высоты нужно достигнуть скорости={pace}");
                }
                if (rate == 0) rate++;
                time = (distance - spacing) / rate;
                WriteLine($"время={time}");
                writer.Write($"время={time}");
                if (rate < supervisor.velocity)
                {
                    WriteLine("низкая скорость");
                    writer.Write("низкая скорость");
                }
                else if (rate > supervisor.velocity)
                {
                    WriteLine("превышение скорости");
                    writer.Write("превышение скорости");
                }
                if (supervisor.pen_points == 1000)
                {
                    Clear();
                    supervisor.rejection();
                    WriteLine("отказ");
                    writer.Write("отказ");
                }
                if (spacing != 0 || spacing != distance) if (height == 0 || rate == 0)
                    {
                        Clear();
                        supervisor.rejection();
                        WriteLine("отказ");
                        writer.Write("отказ");
                    }
                spacing++;
                Thread.Sleep(time);
                Thread.Sleep(1000);
                Clear();
            }
            while (spacing >= (distance / 2) && spacing <= distance)
            {
                WriteLine("клавиша");
                ReadKey();
                WriteLine($"пройденное расстояние={spacing}");
                writer.Write($"пройденное расстояние={spacing}");
                if (spacing == (distance / 2))
                {
                    WriteLine($"второй диспетчер {behalf}");
                    writer.Write($"второй диспетчер {behalf}");
                    manager.n = rand_val.Next(-200, 201);
                }
                WriteLine($"корректировка погодных условий={manager.n}");
                writer.Write($"корректировка погодных условий={manager.n}");
                rate = distance;
                if (event_args.KeyCode == Keys.Right)
                {
                    Button key = new Button();
                    key.PerformClick();
                    rate += 50;
                    manager.shift += rapidity;
                    if (rate > pace)
                    {
                        manager.pen_points += 100;
                        WriteLine($"количество штрафных очков={manager.pen_points}");
                        writer.Write($"количество штрафных очков={manager.pen_points}");
                        manager.decline();
                        WriteLine("снижение");
                        writer.Write("снижение");
                    }
                }
                else if (event_args.KeyCode == Keys.Left)
                {
                    Button key = new Button();
                    key.PerformClick();
                    rate -= 50;
                    manager.shift += rapidity;
                    if (rate > pace)
                    {
                        manager.pen_points += 100;
                        WriteLine($"количество штрафных очков={manager.pen_points}");
                        writer.Write($"количество штрафных очков={manager.pen_points}");
                        manager.decline();
                        WriteLine("снижение");
                        writer.Write("снижение");
                    }
                }
                else if (event_args.KeyCode == Keys.RShiftKey && event_args.KeyCode == Keys.Right)
                {
                    Button key = new Button();
                    key.PerformClick();
                    rate += 150;
                    manager.shift += rapidity;
                    if (rate > pace)
                    {
                        manager.pen_points += 100;
                        WriteLine($"количество штрафных очков={manager.pen_points}");
                        writer.Write($"количество штрафных очков={manager.pen_points}");
                        manager.decline();
                        WriteLine("снижение");
                        writer.Write("снижение");
                    }
                }
                else if (event_args.KeyCode == Keys.RShiftKey && event_args.KeyCode == Keys.Left)
                {
                    Button key = new Button();
                    key.PerformClick();
                    rate -= 150;
                    manager.shift += rapidity;
                    if (rate > pace)
                    {
                        manager.pen_points += 100;
                        WriteLine($"количество штрафных очков={manager.pen_points}");
                        writer.Write($"количество штрафных очков={manager.pen_points}");
                        manager.decline();
                        WriteLine("снижение");
                        writer.Write("снижение");
                    }
                }
                else if (event_args.KeyCode == Keys.Up)
                {
                    Button key = new Button();
                    key.PerformClick();
                    height += 250;
                    manager.altitude += elevation;
                    pitch = 7 * rate + manager.n;
                    if (pitch > 0)
                    {
                        WriteLine($"рекомендуемая высота={pitch}");
                        writer.Write($"рекомендуемая высота={pitch}");
                    }
                    if ((pitch - height) >= 300 || (pitch - height) < 600)
                    {
                        manager.pen_points += 25;
                        WriteLine($"количество штрафных очков={manager.pen_points}");
                        writer.Write($"количество штрафных очков={manager.pen_points}");
                    }
                    else if ((pitch - height) >= 600 || (pitch - height) < 1000)
                    {
                        manager.pen_points += 50;
                        WriteLine($"количество штрафных очков={manager.pen_points}");
                        writer.Write($"количество штрафных очков={manager.pen_points}");
                    }
                    else if ((pitch - height) > 1000)
                    {
                        Clear();
                        manager.crash();
                        WriteLine("крушение");
                        writer.Write($"количество штрафных очков={manager.pen_points}");
                    }
                    if (height < pitch)
                    {
                        WriteLine("нужно поднять самолёт до рекомендуемой высоты");
                        writer.Write("нужно поднять самолёт до рекомендуемой высоты");
                    }
                    else if (height > pitch)
                    {
                        WriteLine("нужно спуститься до рекомендуемой высоты");
                        writer.Write("нужно спуститься до рекомендуемой высоты");
                    }
                }
                else if (event_args.KeyCode == Keys.Down)
                {
                    Button key = new Button();
                    key.PerformClick();
                    height -= 250;
                    manager.altitude += elevation;
                    pitch = 7 * rate + manager.n;
                    if (pitch > 0)
                    {
                        WriteLine($"рекомендуемая высота={pitch}");
                        writer.Write($"рекомендуемая высота={pitch}");
                    }
                    if ((pitch - height) >= 300 || (pitch - height) < 600)
                    {
                        manager.pen_points += 25;
                        WriteLine($"количество штрафных очков={manager.pen_points}");
                        writer.Write($"количество штрафных очков={manager.pen_points}");
                    }
                    else if ((pitch - height) >= 600 || (pitch - height) < 1000)
                    {
                        manager.pen_points += 50;
                        WriteLine($"количество штрафных очков={manager.pen_points}");
                        writer.Write($"количество штрафных очков={manager.pen_points}");
                    }
                    else if ((pitch - height) > 1000)
                    {
                        Clear();
                        manager.crash();
                        WriteLine("крушение");
                        writer.Write($"количество штрафных очков={manager.pen_points}");
                    }
                    if (height < pitch)
                    {
                        WriteLine("нужно поднять самолёт до рекомендуемой высоты");
                        writer.Write("нужно поднять самолёт до рекомендуемой высоты");
                    }
                    else if (height > pitch)
                    {
                        WriteLine("нужно спуститься до рекомендуемой высоты");
                        writer.Write("нужно спуститься до рекомендуемой высоты");
                    }
                }
                else if (event_args.KeyCode == Keys.RShiftKey && event_args.KeyCode == Keys.Up)
                {
                    Button key = new Button();
                    key.PerformClick();
                    height += 500;
                    manager.altitude += elevation;
                    pitch = 7 * rate + manager.n;
                    if (pitch > 0)
                    {
                        WriteLine($"рекомендуемая высота={pitch}");
                        writer.Write($"рекомендуемая высота={pitch}");
                    }
                    if ((pitch - height) >= 300 || (pitch - height) < 600)
                    {
                        manager.pen_points += 25;
                        WriteLine($"количество штрафных очков={manager.pen_points}");
                        writer.Write($"количество штрафных очков={manager.pen_points}");
                    }
                    else if ((pitch - height) >= 600 || (pitch - height) < 1000)
                    {
                        manager.pen_points += 50;
                        WriteLine($"количество штрафных очков={manager.pen_points}");
                        writer.Write($"количество штрафных очков={manager.pen_points}");
                    }
                    else if ((pitch - height) > 1000)
                    {
                        Clear();
                        manager.crash();
                        WriteLine("крушение");
                        writer.Write($"количество штрафных очков={manager.pen_points}");
                    }
                    if (height < pitch)
                    {
                        WriteLine("нужно поднять самолёт до рекомендуемой высоты");
                        writer.Write("нужно поднять самолёт до рекомендуемой высоты");
                    }
                    else if (height > pitch)
                    {
                        WriteLine("нужно спуститься до рекомендуемой высоты");
                        writer.Write("нужно спуститься до рекомендуемой высоты");
                    }
                }
                if (spacing == (distance / 2))
                {
                    WriteLine($"второй диспетчер {behalf}");
                    writer.Write($"второй диспетчер {behalf}");
                }
                WriteLine($"нужная скорость={manager.velocity}");
                writer.Write($"нужная скорость={manager.velocity}");
                int time = (distance - spacing) / rate;
                if (rate < manager.velocity)
                {
                    WriteLine("низкая скорость");
                    writer.Write("низкая скорость");
                }
                else if (rate > manager.velocity)
                {
                    WriteLine("превышение скорости");
                    writer.Write("превышение скорости");
                }
                if (rate < 50)
                {
                    WriteLine(manager.landing);
                    writer.Write(manager.landing);
                }
                if (manager.pen_points == 1000)
                {
                    Clear();
                    manager.rejection();
                    WriteLine("отказ");
                    writer.Write("отказ");
                }
                if (spacing != 0 || spacing != distance) if (height == 0 || rate == 0)
                    {
                        Clear();
                        manager.rejection();
                        WriteLine("отказ");
                        writer.Write("отказ");
                    }
                Thread.Sleep(time);
                Thread.Sleep(1000);
                if (spacing < distance) Clear();
                if (spacing == distance)
                {
                    WriteLine($"количество штрафных очков={manager.pen_points}");
                    writer.Write($"количество штрафных очков={manager.pen_points}");
                }
                spacing++;
            }
        }
    }
    public class Dispatcher
    {
        public int n, pen_points = 0;//штрафные очки
        public Dispatcher()
        {

        }
        public string takeoff = "взлёт", landing = "посадка";
        public void crash()
        {
            Clear();
            WriteLine("самолёт разбился");
        }
        public void rejection()
        {
            Clear();
            WriteLine("полёт завершён преждевременно из-за большого количества штрафов");
        }
        public void decline()
        {
            WriteLine("нужно снизить скорость");
        }
        public event rate_change shift;
        public void rapidity(int rate)
        {
            if (shift != null) shift(rate);
        }
        public event height_change altitude;
        public void elevation(int height)
        {
            if (altitude != null) altitude(height);
        }
        public int velocity = 1000;
    }
    internal class Train_of_plane_pil
    {
        static void Main(string[] args)
        {
            WriteLine("left - уменьшение скорости на 50 км/ч");
            WriteLine("right - увеличение скорости на 50 км/ч");
            WriteLine("shift-right - увеличение скорости на 150 км/ч");
            WriteLine("shift-left - уменьшение скорости на 150 км/ч");
            WriteLine("up - увеличение высоты на 250 м");
            WriteLine("down - уменьшение высоты на 250 м");
            WriteLine("shift-up - увеличение высоты на 500 м");
            WriteLine("shift-down - уменьшение высоты на 500 м");
            Plane aircraft = new Plane();
            KeyEventArgs event_args = new KeyEventArgs(Keys.Up);
            object sender = 0;//сигнатура метода нажатия клавиши
            WriteLine("первый диспетчер");
            string name = ReadLine();
            WriteLine("второй диспетчер");
            string behalf = ReadLine();
            Dispatcher supervisor = new Dispatcher(), manager = new Dispatcher();
            int distance = 100, pace = 1000, spacing = 0;//пройденное расстояние
            Random rand_val = new Random();
            WriteLine($"расстояние={distance}");
            string file_path = "\\\\Keenetic-9922\\внешний диск\\c#\\cs\\cs\\логи.txt";
            using (FileStream stream = new FileStream(file_path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                using (BinaryWriter writer = new BinaryWriter(stream, Encoding.Unicode))
                {
                    aircraft.form_key_down(sender, event_args, writer, spacing, distance, supervisor, manager, rand_val, pace, name, behalf);
                }
            }
        }
    }
}