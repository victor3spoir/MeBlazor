import { Button } from "@/components/ui/button";
import { Fetcher } from "@/features/shared/fetchers";
import PageHeader from "@/features/shared/ui/page-header";
import { TaskItem } from "@/features/tasks/definitions";
import AddTaskDialog from "@/features/tasks/ui/add-task-dialog";
import { Trash2Icon } from "lucide-react";
import Form from "next/form"
import { Suspense } from "react";
export const experimental_ppr = true
export default async function Page() {
  const fetchTask = async () => {
    const fetcher = new Fetcher<TaskItem[]>("/api/taskitems");
    return await fetcher.getAll()
  }
  const { results: tasks, error } = await fetchTask()
  if (error?.status === 500 || tasks === undefined) {
    return (
      <p>Error happens on the backend side <br />
        please, try again later
      </p>
    )
  }

  return (
    <div>
      <PageHeader title="Task" description="normal display" />
      <AddTaskDialog />
      <Suspense fallback={<p>Pending...</p>}>
        <div className="flex flex-col gap-2">
          {tasks.map(task => (
            <article key={task.id} className="w-full flex items-center shadow-sm gap-1 border border-slate-300 rounded-sm">
              <div className="flex-1">
                <h2>{task.taskName}</h2>
              </div>
              <div>
                <Form name="form-delete" action={async () => {
                  "use server"
                  console.log("deleting...", task.id)
                  const fetcher = new Fetcher<TaskItem[]>("/api/taskitems");
                  await fetcher.delete(task.id)
                }}>
                  <Button className="px-2 bg-red-600" type="submit" ><Trash2Icon /></Button>
                </Form>
              </div>
            </article>
          ))}
        </div>
      </Suspense>
    </div>
  )
}