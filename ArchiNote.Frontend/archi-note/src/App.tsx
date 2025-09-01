import "@fontsource/roboto/300.css";
import "@fontsource/roboto/400.css";
import "@fontsource/roboto/500.css";
import "@fontsource/roboto/700.css";
import "./App.css";
import { ThemeProvider, CssBaseline, Container, darkTheme } from "./theme";
import { ProjectList } from "./components/ProjectList/ProjectList";

function App() {
  return (
    <>
      <ThemeProvider theme={darkTheme}>
        <CssBaseline />
        <Container maxWidth="lg">
          <ProjectList />
        </Container>
      </ThemeProvider>
    </>
  );
}

export default App;
