using System;
using System.Collections.Generic;

namespace callcenter
{
	public abstract class Employee {
		protected bool is_available; 

		public bool CanHandle(Call c) {
			//business logic
			return true;
		}

		public void Release<T>(Queue<T> pool) where T: Employee {
			is_available = true;
			pool.Enqueue((T)this);
		}

		public void TryHandle(Call c) {
			is_available = false;
		}
	}

	public class Respondent : Employee {
	}

	public class Manager : Employee {
	}

	public class Director : Employee {
	}

	public class Call {
		private Employee assignee;

		public void Assign(Employee e) {
			assignee = e;
			e.TryHandle(this);
		}

		public void Unassign() {
			assignee = null;
		}
	}

	public class CallCenter {
		Queue<Respondent> r_queue = new Queue<Respondent>();
		Queue<Manager> m_queue = new Queue<Manager>();
		Queue<Director> d_queue = new Queue<Director>();

		public void DispatchCall(Call call) {

			Employee curemployee = r_queue.Dequeue();
			call.Assign(curemployee);
			if(!curemployee.CanHandle(call)) {
				curemployee.Release(r_queue);
				call.Unassign();
				curemployee = m_queue.Dequeue();
			}

			call.Assign(curemployee);
			if(!curemployee.CanHandle(call)) {
				curemployee.Release(m_queue);
				call.Unassign();
				curemployee = d_queue.Dequeue();
			}


		}


	}



	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}
}
