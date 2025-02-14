"use client"
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { handleFileUploadAction } from "@/features/shared/actions";
import PageHeader from "@/features/shared/ui/page-header";
import Form from "next/form";

export default function Page() {

  return (
    <div>
      <PageHeader title="Upload file"
        description="Learn how upload files in Next.js" />
      <div>
        <div className="my-2">
          <h1 className="font-bold text-4xl text-center">Upload profile image</h1>
        </div>
        <Form className="w-[300px] mx-auto" action={handleFileUploadAction} >
          <figure className="w-full aspect-square bg-slate-100 rounded-sm p-2">
            <img src={null} alt="profile image" id="profile-image"
             className="w-full h-full object-cover" />
          </figure>
          <div className="flex flex-col justify-center gap-3">
            <Input type="file" accept=".png, .jpeg, .jpeg" name="profile-image-file" id="profile-image-file"
              onChange={(e) => {
                console.log("===>changed")
                const imgEl = document.querySelector("#profile-image") as HTMLImageElement
                imgEl.src = null
                const file = e.target.files![0]
                const reader = new FileReader()
                reader.onload = (e) => {
                  imgEl.src = e.target?.result as string
                }
                reader.readAsDataURL(file)
              }} />
            <Button>Upload</Button>
          </div>
        </Form>
      </div>
    </div>
  )
}