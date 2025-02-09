import { TrashIcon } from "lucide-react";
import { TaskItem } from "../definitions";
import { Button } from "@/components/ui/button";

export default function TaskCard({ task }: { task: TaskItem }) {

  return (
    <article  draggable className="flex items-center my-3 py-2 px-2 border border-slate-500 rounded-md gap-3">
      <div className="flex-1">
        <h4>{task.taskName}</h4>
      </div>
      <div>
        <Button variant={"ghost"} asChild className="bg-red-400"><TrashIcon color="white" /></Button>
      </div>
    </article>
  )
}