export enum TaskItemStatus {
  TODO, PENDING, DONE
}

export type TaskItem = {
  id: string,
  taskName: string
  status: TaskItemStatus
}