import Link from "next/link";


const learnLinks = [
  { text: "Upload file", url: "/learn/upload-file" },
  { text: "Login form", url: "/learn/login-form" },
]

export default function Page() {

  return (
    <div>
      <h1>Learning section</h1>
      <div>
        <ul className="">
          {learnLinks.map((link) => (
            <li key={link.text} className="py-1 p-3">
              <Link href={link.url}>{link.text}</Link>
            </li>
          ))}
        </ul>
      </div>
    </div>
  )
}