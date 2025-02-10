"use server"

import fs from "fs"
import path from "path"


export async function handleFileUploadAction(formData: FormData) {
  const content = formData.get("profile-image-file") as File
  const fileBuffer = Buffer.from(await (content as Blob).arrayBuffer())
  const pDir = path.join(process.cwd(), "public")

    await fs.writeFile(path.join(pDir, content.name), fileBuffer, (err) => { console.log(err) })

}