import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../layout/App";
import Home from "../../features/Home";
import { PlanetDetail } from "../../features/PlanetDetail";

export const routes: RouteObject[] = [
	{
		path: '/',
		element: <App />,
		children: [
			{path: '', element: <Home />},
			{path: 'planet/:id', element: <PlanetDetail />}
		]
	}
]


export const router = createBrowserRouter(routes);