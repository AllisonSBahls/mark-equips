import "./styles.css";
import { AiFillGithub, AiFillInstagram, AiFillLinkedin } from "react-icons/ai";

export default function Footer() {
  return (
    <div>
      <div className="footer">
        <h1>Desenvolvido por Allison Sousa Bahls</h1>
        <a href="https://github.com/allisonsbahls">
          <AiFillGithub className="icon-footer github" />
        </a>
        <a href="https://www.instagram.com/allisonsbahls">
          <AiFillInstagram className="icon-footer instagram" />
        </a>
        <a href="https://www.linkedin.com/in/allison-bahls/">
          <AiFillLinkedin className="icon-footer linkdin" />
        </a>
      </div>
    </div>
  );
}
