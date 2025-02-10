import Link from "next/link"

export default function Navbar() {

  const urls = [
    { name: "Home", link: "/" },
    { name: "learn/upload-file", link: "/learn/upload-file" },
    { name: "Weather(Local)", link: "/local-weather" },
    { name: "Task", link: "/tasks" },
    { name: "Task(kanban)", link: "/tasks/kanban" },
  ]

  return (
    <header className="flex justify-between items-center py-4 px-2 border-b-2">
      <Link href={"/"}>
        <h1 className="font-bold text-2xl text-indigo-800">MeBlazor</h1>
      </Link>
      <nav>
        <ul className="flex items-center justify-start gap-3">
          {urls.map((url, index) => (
            <li key={index} className="link-item">
              <Link href={url.link}>{url.name}</Link>
            </li>
          ))}
        </ul>
      </nav>
    </header>
  )
}