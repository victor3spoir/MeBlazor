"use server"

import { Fetcher } from "../shared/fetchers";
import { TaskItem } from "./definitions";

const fetcher = new Fetcher<TaskItem[]>("/api/taskitems");
export async function createTask(prevState: undefined, formData: FormData) {
  const entries = Object.fromEntries(formData)
  console.log(entries)
  return await fetcher.create(entries)
}