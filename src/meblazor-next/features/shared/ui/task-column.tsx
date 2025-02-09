"use client"
import { TaskItem } from "@/features/tasks/definitions";
import TaskCard from "@/features/tasks/ui/task-card";
import React from "react";

export default function TaskColumn({ title, status, tasks, ...restProps }: {
  title: string, status: TaskItem["status"],
  tasks: TaskItem[], restProps?: React.HTMLAttributes
}) {

  const filteredTask = tasks.filter(task => task.status === status)

  return (
    <div  {...restProps}>
      <h3>{title}</h3>
      <div className="border-slate-300 py-3 px-2 min-h-[500px] min-w-[200px]" onDragOver={(e) => e.preventDefault()}
        onDrag={(e) => { console.log(e) }}>
        {filteredTask.map(task => (
          <TaskCard task={task} key={task.id} />
        ))}


      </div>

    </div>
  )
}