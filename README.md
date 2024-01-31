# Super Linter GitHub Actions

GitHub Actions workflow for linting the code base using the Super Linter.

## Overview

This GitHub Actions workflow is designed to lint the code base using the [Super Linter](https://github.com/github/super-linter). The Super Linter checks for various code quality issues in different types of files within the specified source path.

## Workflow Details

- **Trigger:** The workflow is triggered on pushes and pull requests to the `master` or `main` branches.
- **Job:** The workflow runs on an `ubuntu-latest` virtual machine.
- **Linting:** The Super Linter is used to validate the code base.
  - Source path: `Assets/Scripts/**/*.cs`

## Usage

1. Ensure the Super Linter GitHub Action workflow file (`.github/workflows/lint.yml`) is present in your repository.
2. Push or create a pull request to the `master` or `main` branch to trigger the workflow.
3. The workflow will check for linting issues in the specified source path.

## Configuration

The workflow can be customized by modifying the Super Linter configuration in the workflow file.

### Super Linter Configuration:

- **Validate All Codebase:** `false`
- **Default Branch:** `main`
- **GitHub Token:** Used for authentication (`${{ secrets.GITHUB_TOKEN }}`)
- **Source Path:** `Assets/Scripts/**/*.cs`

For more details on Super Linter configuration, refer to the [official documentation](https://github.com/github/super-linter).

## License

This project is licensed under the [MIT License](LICENSE).
