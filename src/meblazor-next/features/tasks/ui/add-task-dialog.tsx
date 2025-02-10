"use client"

import { Button } from "@/components/ui/button"
import { Dialog, DialogContent, DialogDescription, DialogFooter, DialogHeader, DialogTitle, DialogTrigger } from "@/components/ui/dialog"
import { Input } from "@/components/ui/input"
import Form from "next/form"
import { createTask } from "../actions"
import { useActionState } from "react"


export default function AddTaskDialog() {

  const [createTaskAction] = useActionState(createTask, { message: "" })
  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button variant="outline">Add new task</Button>
      </DialogTrigger>
      <DialogContent className="sm:max-w-[425px]">
        <DialogHeader>
          <DialogTitle>Add new task</DialogTitle>
          <DialogDescription>
            Add new task
          </DialogDescription>
        </DialogHeader>
        <Form className="grid gap-4 py-4" action={createTaskAction}>
          <div className="">
            <Input id="taskName" name="taskName" className="col-span-3" />
          </div>
        </Form>
        <DialogFooter>
          <DialogTrigger asChild>
            <Button type="submit">Save changes</Button>
          </DialogTrigger>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  )
}