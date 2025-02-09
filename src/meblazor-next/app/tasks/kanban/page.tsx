import { Fetcher } from "@/features/shared/fetchers";
import PageHeader from "@/features/shared/ui/page-header";
import TaskColumn from "@/features/shared/ui/task-column";
import { TaskItem } from "@/features/tasks/definitions";




export default async function Page() {

  const loadData = async () => {
    "use server"
    const fetcher = new Fetcher<TaskItem>("/api/taskitems")
    return await fetcher.getAll()
  }

  const tasks: TaskItem[] = await loadData()
  console.log(tasks)

  return (
    <div>
      <PageHeader title="Task as kanban" description="small description..." />
      <div className="flex items-start justify-evenly">
        <TaskColumn title="Todo" status={0}  tasks={tasks} />
        <TaskColumn title="Pending" status={1} tasks={tasks} />
        <TaskColumn title="Done" status={2} tasks={tasks} />
      </div>
    </div>
  )
}