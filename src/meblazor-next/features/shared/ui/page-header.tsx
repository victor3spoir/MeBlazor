"use client"
export default function PageHeader({ title, description }: { title: string, description?: string }) {

  return (
    <div className="bg-slate-100 shadow-sm rounded-sm py-3 px-2 my-3 outline-indigo-500">
      <dl>
        <dt className="text-2xl my-2">{title}</dt>
        <dd>{description}</dd>
      </dl>
    </div>
  )
}