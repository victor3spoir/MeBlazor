import { Button } from "@/components/ui/button";
import Link from "next/link";


const learnLinks = [
  { text: "Upload file", url: "/learn/upload-file" },
  { text: "Login form", url: "/learn/login-form" },
  { text: "Tailwindcss", url: "/learn/tailwind" },
]

export default function Page() {

  return (
    <div>
      <h1>Learning section</h1>
      <div>
        <ul className="list-disc">
          {learnLinks.map((link) => (
            <li key={link.text} className="py-1 p-3">

              <Link href={link.url} className="link-item">
                <Button variant={"link"} >
                  {link.text}
                </Button>
              </Link>
            </li>
          ))}
        </ul>
      </div>
    </div >
  )
}